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

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [Required(ErrorMessage = "Digite a data de contratação do funcionário!")]
        [Display(Name = "Data de Contratação")]
        public decimal VLCompra { get; set; }

        [Required(ErrorMessage = "Digite a data de contratação do funcionário!")]
        [Display(Name = "Data de Contratação")]
        public string DEEquipamentoRural { get; set; }

        [Required(ErrorMessage = "Digite a data de contratação do funcionário!")]
        [Display(Name = "Data de Contratação")]
        public bool STAlugado { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a data de contratação do funcionário!")]
        [Display(Name = "Data de Contratação")]
        public DateTime DTCompra { get; set; }
    }
}