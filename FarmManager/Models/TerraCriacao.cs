using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace FarmManager.Models
{
    public abstract class TerraCriacao : Terra
    {
        [Display(Name = "Vacas presentes")]
        public int NRVacasAlocadas { get; set; }
        [Display(Name = "Capacidade máxima")]
        public int NRMaximoVacas { get; set; }
    }
}