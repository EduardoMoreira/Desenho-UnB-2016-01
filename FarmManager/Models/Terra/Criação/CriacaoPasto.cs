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
            Pasto pasto = (Pasto)terra;
            db.Pastos.Add(pasto);
            db.SaveChanges();
            base.criarTerra(terra);
        }

        public override void excluirTerra(Terra terra)
        {
            Pasto pasto = (Pasto)terra;
            db.Pastos.Attach(pasto);
            db.Pastos.Remove(pasto);
            db.SaveChanges();
            base.excluirTerra(terra);
        }
    }
}