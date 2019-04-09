using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProjetoWeb.Models;

namespace ProjetoWeb.Services
{
    public class UsersServices : IUsersServices
    {
        //search list: 1:GetUsers| 2:FindById | 3:AddUser| 4:RemoveById | 5:Update
        private readonly List<UserModel> _users;
        private readonly string _connectionString;
        private int lastId;
        private int rows;

        public UsersServices()
        {
            lastId = new int();
            _users = new List<UserModel>();
            _connectionString = @"server=localhost;user=root;password=135Mudar@;database=projetoweb";
        }

        public UserModel AddUser(UserModel userToAdd)
        {
            var query = "INSERT INTO usuario (NomeCompleto, Senha, Email, IdTipoUsuario) " +
                        "VALUES (@Nome, @Senha, @Email, @TipoUsuarioId)";


            ContactServer(null, query, userToAdd, null, 3);

            return FindById(lastId);
        }

        public UserModel FindById(int id)
        {
            var userFound = new UserModel();
            var query = "SELECT * FROM usuario WHERE IdUsuario = " + id;

            ContactServer(null, query, userFound, null, 2);

            return userFound.IdUser == -1 ? null : userFound;
        }

        public List<UserModel> GetUsers()
        {
            var query = "SELECT * FROM usuario";

            ContactServer(_users, query, null, null, 1);

            return _users;
        }

        public int RemoveById(int id)
        {
            var query = "DELETE FROM usuario WHERE IdUsuario = " + id;
            ContactServer(null, query, null, null, 4);

            return rows;
        }

        public int Update(UserModel userToEdit, UserModel userEditions)
        {
            var query = "UPDATE usuario SET ";

            ContactServer(null, query, userEditions, userToEdit, 5);

            return rows;
        }

        public bool Authenticate(UserModel user)
        {
            var query = $"select 1 from usuario where Email like @Email and Senha like @Senha";

            ContactServer(null, query, user, null, 6);

            return rows != 0;
        }


        public void ContactServer(List<UserModel> list, string _query, UserModel model, UserModel originalModel, int search)
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
                        cmd.Parameters.AddWithValue("@Nome", model.NomeCompleto);
                        cmd.Parameters.AddWithValue("@Senha", model.Senha);
                        cmd.Parameters.AddWithValue("@Email", model.Email);
                        cmd.Parameters.AddWithValue("@TipoUsuarioId", model.TipoUsuarioId);

                        cmd.ExecuteNonQuery();
                        lastId = Convert.ToInt32(cmd.LastInsertedId);
                    }
                    else if (search == 4)//DELETE
                    {
                        rows = cmd.ExecuteNonQuery();
                    }
                    else if(search == 5)//UPDATE
                    {
                        if (!model.NomeCompleto.Equals(originalModel.NomeCompleto))
                        {
                            _query += "NomeCompleto = @Nome WHERE IdUsuario = " + model.IdUser;
                            cmd.Parameters.AddWithValue("@Nome", model.NomeCompleto);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE usuario SET ";
                        }

                        if(!model.Email.Equals(originalModel.Email))
                        {
                            _query += "Email = @Email WHERE IdUsuario = " + model.IdUser;
                            cmd.Parameters.AddWithValue("@Email", model.Email);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE usuario SET ";
                        }

                        if (model.TipoUsuarioId != originalModel.TipoUsuarioId)
                        {
                            _query += "IdTipoUsuario = @IdTipoUsuario WHERE IdUsuario = " + model.IdUser;
                            cmd.Parameters.AddWithValue("@IdTipoUsuario", model.TipoUsuarioId);
                            cmd.CommandText = _query;
                            rows = cmd.ExecuteNonQuery();
                            _query = "UPDATE usuario SET ";
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
                                    list.Add(new UserModel
                                    {
                                        IdUser = reader.GetInt32(reader.GetOrdinal("IdUsuario")),
                                        NomeCompleto = reader.GetString(reader.GetOrdinal("NomeCompleto")),
                                        Senha = reader.GetString(reader.GetOrdinal("Senha")),
                                        Email = reader.GetString(reader.GetOrdinal("Email")),
                                        TipoUsuarioId = reader.GetInt32(reader.GetOrdinal("IdTipoUsuario"))
                                    });
                                }
                            }
                            else if (search == 2)// LIST ONE
                            {
                                if (reader.Read())
                                {
                                    model.IdUser = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
                                    model.NomeCompleto = reader.GetString(reader.GetOrdinal("NomeCompleto"));
                                    model.Senha = reader.GetString(reader.GetOrdinal("Senha"));
                                    model.Email = reader.GetString(reader.GetOrdinal("Email"));
                                    model.TipoUsuarioId = reader.GetInt32(reader.GetOrdinal("IdTipoUsuario"));
                                }
                                else
                                {
                                    model.IdUser = -1;
                                }
                            }
							else if(search == 6)//Any()
							{
								rows = reader.HasRows ? 1 : 0;
							}
                        }
                    }
                }

                dbConnection.Close();
            }
        }
    }
}
