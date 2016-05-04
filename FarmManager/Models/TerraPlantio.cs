using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public enum Grao
    {
        Milho, Soja
    }

    public class TerraPlantio : Terra
    {
        public DateTime DTPlantio { get; set; }
        public DateTime? DTColheita { get; set; }
        public Grao TPGrao { get; set; }
    }
}