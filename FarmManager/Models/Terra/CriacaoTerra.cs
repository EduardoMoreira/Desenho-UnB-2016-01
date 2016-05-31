using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class CriacaoTerra
    {
        protected FarmContext db = new FarmContext();

        public virtual void criarTerra(Terra terra)
        {
            //O resto da implementação está nas classes filhas

            TerraFazenda terraFazenda = db.TerraFazenda.FirstOrDefault();
            if(terraFazenda != null)
            {
                terraFazenda.adicionarTerra(terra);
                terraFazenda.update(terra.NRHectares);
            }
        }

        public virtual void excluirTerra(Terra terra)
        {
            //O resto da implementação está nas classes filhas

            TerraFazenda terraFazenda = db.TerraFazenda.FirstOrDefault();
            if (terraFazenda != null)
            {
                terraFazenda.removerTerra(terra);
                terraFazenda.update(terra.NRHectares * -1);
            }
        }
    }
}