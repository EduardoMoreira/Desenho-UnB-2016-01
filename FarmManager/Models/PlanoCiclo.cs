using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class PlanoCiclo
    {
        public virtual IList<IList<Vaca>> RetornaListaVacas()
        {
            throw new Exception("Função não implementada!");
        }
    }
}