using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class CriacaoPasto : CriacaoTerra
    {
        public override void criarTerra(Terra terra)
        {
            base.db.Pastos.Add((Pasto)terra);
            base.db.SaveChanges();
            base.criarTerra(terra);
        }

        public override void excluirTerra(Terra terra)
        {
            base.db.Pastos.Remove((Pasto)terra);
            base.db.SaveChanges();
            base.excluirTerra(terra);
        }
    }
}