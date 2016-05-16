using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Data de Plantio")]
        public DateTime DTPlantio { get; set; }
        [Display(Name = "Data de Colheita")]
        public DateTime? DTColheita { get; set; }
        [Display(Name = "Tipo de Grão")]
        public Grao TPGrao { get; set; }
    }
}