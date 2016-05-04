using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class TerraCriacao : Terra
    {
        public int NRVacasAlocadas { get; set; }
        public int NRMaximoVacas { get; set; }
    }
}