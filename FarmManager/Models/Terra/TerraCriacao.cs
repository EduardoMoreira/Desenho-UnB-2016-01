using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FarmManager.Models
{
    public abstract class TerraCriacao : Terra
    {
        [Display(Name = "Gados presentes")]
        public int NRGadosAlocadas { get; set; }

        [Display(Name = "Capacidade máxima")]
        public int NRMaximoGados { get; set; }
    }
}