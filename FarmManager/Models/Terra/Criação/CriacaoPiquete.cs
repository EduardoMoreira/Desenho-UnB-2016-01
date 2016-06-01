using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class CriacaoPiquete : CriacaoTerra
    {
        public override void criarTerra(Terra terra)
        {
            Piquete piquete = (Piquete)terra;
            db.Piquetes.Add(piquete);
            db.SaveChanges();
            base.criarTerra(terra);
        }

        public override void excluirTerra(Terra terra)
        {
            Piquete piquete = (Piquete)terra;
            db.Piquetes.Attach(piquete);
            db.Piquetes.Remove(piquete);
            db.SaveChanges();
            base.excluirTerra(terra);
        }
    }
}