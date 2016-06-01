using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FarmManager.Models
{
    public class TerraNua : Terra
    {
        [Display(Name = "Descrição da terra nua")]
        public string DETerra { get; set; }
    }
}