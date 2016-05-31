using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Soja : Grao
    {
        private FarmContext db = new FarmContext();

        public override void update(int quantidade)
        {
            Grao grao = db.Sojas.FirstOrDefault();
            grao.NRQuantidade += quantidade;
            grao.DTAtualizacao = DateTime.Now;
            db.SaveChanges();
        }
    }
}