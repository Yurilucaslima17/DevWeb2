using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;
using ProjetoWeb.Services.DisciplinaServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private readonly IDisciplinaServices _services;

        public DisciplinaController(IDisciplinaServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("AddDisciplina")]
        public ActionResult<DisciplinaModel> AddDisciplina(DisciplinaModel discToAdd)
        {
            var user = _services.AddDisciplina(discToAdd);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpGet]
        [Route("GetDisciplina")]
        public ActionResult<IEnumerable<DisciplinaModel>> GetDisciplina()
        {
            var disciplinas = _services.GetDisciplinas();

            if (disciplinas.Count == 0)
                return NotFound();

            return disciplinas;
        }

        [HttpGet]
        [Route("GetDisciplinaById")]
        public ActionResult<DisciplinaModel> GetDisciplinaById(string id)
        {
            var user = _services.FindById(string.IsNullOrEmpty(id) ? -1 : Convert.ToInt32(id));

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        [Route("AlterDisciplina")]
        public ActionResult<DisciplinaModel> AlterDisciplina(int id, DisciplinaModel discEditions)
        {
            if (discEditions == null || discEditions.IdMateria != id)
                return BadRequest();

            var discToEdit = _services.FindById(id);

            if (discToEdit == null)
                return NotFound();

            _services.Update(discToEdit, discEditions);

            return _services.FindById(id);
        }

        [HttpDelete]
        [Route("DeleteDisciplina")]
        public string DeleteDisciplina(int id)
        {
            var resp = "";

            var user = _services.FindById(id);

            if (user == null)
                resp = "Disciplina nao encontrada";

            var deletados = _services.RemoveById(id);

            if (deletados > 1)
                resp = "Foram removidas " + deletados + " com sucesso";
            else if (deletados == 1)
                resp = "Disciplina removida com sucesso";

            return resp;
        }
    }
}
