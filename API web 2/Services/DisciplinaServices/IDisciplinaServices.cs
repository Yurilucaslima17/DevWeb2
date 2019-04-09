using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services.DisciplinaServices
{
    public interface IDisciplinaServices
    {
        DisciplinaModel AddDisciplina(DisciplinaModel discToAdd);

        List<DisciplinaModel> GetDisciplinas();

        DisciplinaModel FindById(int id);

        int RemoveById(int id);

        int Update(DisciplinaModel discToEdit, DisciplinaModel originalDisc);
    }
}
