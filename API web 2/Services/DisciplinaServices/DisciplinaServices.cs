using MySql.Data.MySqlClient;
using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services.DisciplinaServices
{
    public class DisciplinaServices : IDisciplinaServices
    {
        //search list: 1:GetDisciplinas| 2:FindById | 3:AddDisciplina| 4:RemoveById | 5:Update
        private static string tableName = "disciplina";
        private readonly List<DisciplinaModel> _materias;
        private readonly string _connectionString;
        private int lastId;
        private int rows;

        public DisciplinaServices()
        {
            lastId = new int();
            _materias = new List<DisciplinaModel>();
            _connectionString = @"server=localhost;user=root;password=135Mudar@;database=projetoweb";
        }

        public DisciplinaModel AddDisciplina(DisciplinaModel discToAdd)
        {
            var query = "INSERT INTO " + tableName + " (NomeMateria) " +
                        "VALUES (@Nome)";


            ContactServer(null, query, discToAdd, null, 3);

            return FindById(lastId);
        }

        public DisciplinaModel FindById(int id)
        {
            var discFound = new DisciplinaModel();
            var query = "SELECT * FROM " + tableName + " WHERE IdMateria = " + id;

            ContactServer(null, query, discFound, null, 2);

            return discFound.IdMateria == -1 ? null : discFound;
        }

        public List<DisciplinaModel> GetDisciplinas()
        {
            var query = "SELECT * FROM " + tableName;

            ContactServer(_materias, query, null, null, 1);

            return _materias;
        }

        public int RemoveById(int id)
        {
            var query = "DELETE FROM " + tableName + " WHERE IdMateria = " + id;
            ContactServer(null, query, null, null, 4);

            return rows;
        }

        public int Update(DisciplinaModel discToEdit, DisciplinaModel originalDisc)
        {
            throw new NotImplementedException();
        }

        public void ContactServer(List<DisciplinaModel> list, string _query, DisciplinaModel model, DisciplinaModel originalModel, int search)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                using (var cmd = dbConnection.CreateCommand())
                {
                    cmd.CommandText = _query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Connection = dbConnection;

                    dbConnection.Open();

                    if (search == 3)//ADD
                    {
                        cmd.Parameters.AddWithValue("@Nome", model.NomeMateria);

                        cmd.ExecuteNonQuery();
                        lastId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                    else if (search == 4)//DELETE
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
                    else if (search == 5)//UPDATE
                    {
                        if (!model.NomeMateria.Equals(originalModel.NomeMateria))
                        {
                            _query += "NomeMateria = @Nome WHERE IdMateria = " + model.IdMateria;
                            cmd.Parameters.AddWithValue("@Nome", model.NomeMateria);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE " + tableName + " SET ";
                        }
                    }
                    else
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (search == 1)//LIST ALL
                            {
                                while (reader.Read())
                                {
                                    list.Add(new DisciplinaModel
                                    {
                                        IdMateria = reader.GetInt32(reader.GetOrdinal("IdMateria")),
                                        NomeMateria = reader.GetString(reader.GetOrdinal("NomeMateria"))
                                    });
                                }
                            }
                            else if (search == 2)// LIST ONE
                            {
                                if (reader.Read())
                                {
                                    model.IdMateria = reader.GetInt32(reader.GetOrdinal("IdMateria"));
                                    model.NomeMateria = reader.GetString(reader.GetOrdinal("NomeMateria"));
                                }
                                else
                                {
                                    model.IdMateria = -1;
                                }
                            }
                        }
                    }
                }

                dbConnection.Close();
            }
        }
    }
}
