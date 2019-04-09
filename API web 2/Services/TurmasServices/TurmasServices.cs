using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetoWeb.Models;

namespace ProjetoWeb.Services.TurmasServices
{
    public class TurmasServices : ITurmasServices
    {
        //search list: 1:GetDisciplinas| 2:FindById | 3:AddDisciplina| 4:RemoveById | 5:Update
        private static string tableName = "turmas";
        private readonly List<TurmasModel> _turmas;
        private readonly string _connectionString;
        private int lastId;
        private int rows;

        public TurmasServices()
        {
            lastId = new int();
            _turmas = new List<TurmasModel>();
            _connectionString = @"server=localhost;user=root;password=135Mudar@;database=projetoweb";
        }

        public TurmasModel AddTurma(TurmasModel turmaToAdd)
        {
            var query = "INSERT INTO " + tableName + " (CodigoTurma, Ano, Semestre, IdMateria, IdProfessor) " +
                        "VALUES (@Nome, @Ano, @Semestre, @IdMateria, @IdProfessor)";


            ContactServer(null, query, turmaToAdd, null, 3);

            return FindById(lastId);
        }

        public TurmasModel FindById(int id)
        {
            var turmaFound = new TurmasModel();
            var query = "SELECT * FROM " + tableName + " WHERE IdTurma = " + id;

            ContactServer(null, query, turmaFound, null, 2);

            return turmaFound.IdMateria == -1 ? null : turmaFound;
        }

        public List<TurmasModel> GetTurmas()
        {
            var query = "SELECT * FROM " + tableName;

            ContactServer(_turmas, query, null, null, 1);

            return _turmas;
        }

        public int RemoveById(int id)
        {
            var query = "DELETE FROM " + tableName + " WHERE IdTurma = " + id;
            ContactServer(null, query, null, null, 4);

            return rows;
        }

        public int Update(TurmasModel discToEdit, TurmasModel originalDisc)
        {
            throw new NotImplementedException();
        }

        public void ContactServer(List<TurmasModel> list, string _query, TurmasModel model, TurmasModel originalModel, int search)
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
                        cmd.Parameters.AddWithValue("@Nome", model.CodigoTurma);
                        cmd.Parameters.AddWithValue("@Ano", model.Ano);
                        cmd.Parameters.AddWithValue("@Semestre", model.Semestre);
                        cmd.Parameters.AddWithValue("@IdMateria", model.IdMateria);
                        cmd.Parameters.AddWithValue("@IdProfessor", model.IdProfessor);

                        cmd.ExecuteNonQuery();
                        lastId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                    else if (search == 4)//DELETE
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
                    else if (search == 5)//UPDATE
                    {
                        if (!model.CodigoTurma.Equals(originalModel.CodigoTurma))
                        {
                            _query += "CodigoTurma = @parmToChange WHERE IdTurma = " + model.IdTurma;
                            cmd.Parameters.AddWithValue("@parmToChange", model.CodigoTurma);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE " + tableName + " SET ";
                        }

                        if (model.Ano != originalModel.Ano)
                        {
                            _query += "Ano = @parmToChange WHERE IdTurma = " + model.IdTurma;
                            cmd.Parameters.AddWithValue("@parmToChange", model.CodigoTurma);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE " + tableName + " SET ";
                        }

                        if (model.Semestre != originalModel.Semestre)
                        {
                            _query += "Semestre = @parmToChange WHERE IdTurma = " + model.IdTurma;
                            cmd.Parameters.AddWithValue("@parmToChange", model.CodigoTurma);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE " + tableName + " SET ";
                        }

                        if (model.IdMateria != originalModel.IdMateria)
                        {
                            _query += "IdMateria = @parmToChange WHERE IdTurma = " + model.IdTurma;
                            cmd.Parameters.AddWithValue("@parmToChange", model.CodigoTurma);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE " + tableName + " SET ";
                        }

                        if (model.IdProfessor != originalModel.IdProfessor)
                        {
                            _query += "IdProfessor = @parmToChange WHERE IdTurma = " + model.IdTurma;
                            cmd.Parameters.AddWithValue("@parmToChange", model.CodigoTurma);
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
                                    list.Add(new TurmasModel
                                    {
                                        IdTurma = reader.GetInt32(reader.GetOrdinal("IdTurma")),
                                        CodigoTurma = reader.GetString(reader.GetOrdinal("CodigoTurma")),
                                        Ano = reader.GetInt32(reader.GetOrdinal("Ano")),
                                        Semestre = reader.GetInt32(reader.GetOrdinal("Semestre")),
                                        IdMateria = reader.GetInt32(reader.GetOrdinal("IdMateria")),
                                        IdProfessor = reader.GetInt32(reader.GetOrdinal("IdProfessor")),
                                    });
                                }
                            }
                            else if (search == 2)// LIST ONE
                            {
                                if (reader.Read())
                                {
                                    model.IdTurma = reader.GetInt32(reader.GetOrdinal("IdTurma"));
                                    model.CodigoTurma = reader.GetString(reader.GetOrdinal("CodigoTurma"));
                                    model.Ano = reader.GetInt32(reader.GetOrdinal("Ano"));
                                    model.Semestre = reader.GetInt32(reader.GetOrdinal("Semestre"));
                                    model.IdMateria = reader.GetInt32(reader.GetOrdinal("IdMateria"));
                                    model.IdProfessor = reader.GetInt32(reader.GetOrdinal("IdProfessor"));
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
