using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class UserModel
    {
        public int IdUser { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
