using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Models
{
    public class TurmasModel
    {
        public int IdTurma { get; set; }
        public int IdMateria { get; set; }
        public int IdProfessor { get; set; }
        public string CodigoTurma { get; set; }
        public int Ano { get; set; }
        public int Semestre { get; set; }
    }
}
