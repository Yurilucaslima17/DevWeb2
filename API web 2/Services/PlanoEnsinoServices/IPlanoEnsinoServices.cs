using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services.PlanoEnsinoServices
{
    public interface IPlanoEnsinoServices
    {
        PlanoEnsinoModel AddPlanoEnsino(PlanoEnsinoModel p_EnsinoToAdd);

        List<PlanoEnsinoModel> GetPlanoEnsino();

        PlanoEnsinoModel FindById(int id);

        int RemoveById(int id);

        int Update(PlanoEnsinoModel p_EnsinoToEdit, PlanoEnsinoModel originalP_Ensino);
    }
}
