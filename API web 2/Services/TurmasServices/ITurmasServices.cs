using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services.TurmasServices
{
    public interface ITurmasServices
    {
        TurmasModel AddTurma(TurmasModel turmaToAdd);

        List<TurmasModel> GetTurmas();

        TurmasModel FindById(int id);

        int RemoveById(int id);

        int Update(TurmasModel turmaToEdit, TurmasModel originalTurma);
    }
}
