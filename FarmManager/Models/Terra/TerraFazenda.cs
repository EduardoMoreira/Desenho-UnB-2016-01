using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class TerraFazenda : Terra
    {
        private FarmContext db = new FarmContext();

        [NotMapped]
        private List<Terra> listaTerra = new List<Terra>();

        public List<Terra> adicionarTerra(Terra terra)
        {
            listaTerra.Add(terra);
            return listaTerra;
        }

        public List<Terra> removerTerra(Terra terra)
        {
            listaTerra.Remove(terra);
            return listaTerra;
        }

        public void update(int quantidade)
        {
            TerraFazenda terraFazenda = db.TerraFazenda.FirstOrDefault();
            terraFazenda.NRHectares += quantidade;
            db.SaveChanges();
        }
    }
}