using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Milho : Grao
    {
        private FarmContext db = new FarmContext();

        public override void update(int quantidade)
        {
            Grao grao = db.Milhos.FirstOrDefault();
            grao.NRQuantidade += quantidade;
            grao.DTAtualizacao = DateTime.Now;
            db.SaveChanges();
        }
    }
}