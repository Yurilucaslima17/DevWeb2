using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoWeb.Models;

namespace ProjetoWeb.Services
{
    public interface IUsersServices
    {
        UserModel AddUser(UserModel userToAdd);

		bool Authenticate(UserModel user);

        List<UserModel> GetUsers();

        UserModel FindById(int id);

        int RemoveById(int id);

        int Update(UserModel userToEdit, UserModel originalUser);
    }
}
