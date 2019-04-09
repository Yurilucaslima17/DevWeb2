using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Services.TurmasServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmasServices _services;

        public TurmaController(ITurmasServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddTurma")]
        public ActionResult<TurmasModel> AddTurma(TurmasModel turmaToAdd)
        {
            var turma = _services.AddTurma(turmaToAdd);

            if (turma == null)
                return NotFound();

            return turma;
        }

        [HttpGet]
        [Route("GetTurma")]
        public ActionResult<IEnumerable<TurmasModel>> GetTurma()
        {
            var turmas = _services.GetTurmas();

            if (turmas.Count == 0)
                return NotFound();

            return turmas;
        }

        [HttpGet]
        [Route("GetTurmaById")]
        public ActionResult<TurmasModel> GetTurmaById(string id)
        {
            var turma = _services.FindById(string.IsNullOrEmpty(id) ? -1 : Convert.ToInt32(id));

            if (turma == null)
                return NotFound();

            return turma;
        }

        [HttpPost]
        [Route("AlterTurma")]
        public ActionResult<TurmasModel> AlterTurma(int id, TurmasModel turmaEditions)
        {
            if (turmaEditions == null || turmaEditions.IdMateria != id)
                return BadRequest();

            var turmaToEdit = _services.FindById(id);

            if (turmaToEdit == null)
                return NotFound();

            _services.Update(turmaToEdit, turmaEditions);

            return _services.FindById(id);
        }

        [HttpDelete]
        [Route("DeleteTurma")]
        public string DeleteTurma(int id)
        {
            var resp = "";

            var user = _services.FindById(id);

            if (user == null)
                resp = "Turma nao encontrada";

            var deletados = _services.RemoveById(id);

            if (deletados > 1)
                resp = "Foram removidas " + deletados + " com sucesso";
            else if (deletados == 1)
                resp = "Turma removida com sucesso";

            return resp;
        }
    }
}
