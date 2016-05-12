using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class EquipamentoRural
    {
        [Key]
        public int CDEquipamentoRural { get; set; }
        public decimal VLCompra { get; set; }
        public String DEEquipamentoRural { get; set; }
        public bool STAlugado { get; set; }
        public DateTime DTCompra { get; set; }
    }
}