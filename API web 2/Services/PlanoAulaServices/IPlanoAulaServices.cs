using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Services.PlanoAulaServices
{
    public interface IPlanoAulaServices
    {
        PlanoAulaModel AddPlanoAula(PlanoAulaModel p_AulaToAdd);

        List<PlanoAulaModel> GetPlanoAula();

        PlanoAulaModel FindById(int id);

        int RemoveById(int id);

        int Update(PlanoAulaModel p_AulaToEdit, PlanoAulaModel originalP_Aula);
    }
}
