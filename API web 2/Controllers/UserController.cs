using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Services;

namespace ProjetoWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersServices _services;

        public UserController(IUsersServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddUsers")]
        public ActionResult<UserModel> AddUser(UserModel userToAdd)
        {
            var user = _services.AddUser(userToAdd);

            if (user == null)
                return NotFound();

            return user;
        }
		
		[HttpPost("Authenticate")]
		public bool Authenticate(UserModel user)
		{
			return _services.Authenticate(user);
		}

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var users = _services.GetUsers();

            if (users.Count == 0)
                return NotFound();

            return users;
        }

        [HttpGet]
        [Route("GetUserById")]
        public ActionResult<UserModel> GetUserById(string id)
        {
            var user = _services.FindById(string.IsNullOrEmpty(id) ? -1 : Convert.ToInt32(id));

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        [Route("AlterUser")]
        public ActionResult<UserModel> AlterUser(int id, UserModel userEditions)
        {
            if (userEditions == null || userEditions.IdUser != id)
                return BadRequest();

            var userToEdit = _services.FindById(id);

            if (userToEdit == null)
                return NotFound();

            _services.Update(userToEdit, userEditions);

            return _services.FindById(id);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public string DeleteUser(int id)
        {
            var resp = "";

            var user = _services.FindById(id);

            if (user == null)
                resp = "Usuario nao encontrado";

            var deletados = _services.RemoveById(id);

            if (deletados > 1)
                resp = "Foram removidos " + deletados + " com sucesso";
            else if (deletados == 1)
                resp = "Usuario removido com sucesso";

            return resp;
        }
    }
}