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
        [Required(ErrorMessage = "Digite a data o valor de aquisição!")]
        [Display(Name = "Valor de aquisição")]
        public decimal VLCompra { get; set; }

        [Required(ErrorMessage = "Digite o nome do equipamento!")]
        [Display(Name = "Nome do equipamento")]
        public string DEEquipamentoRural { get; set; }

        [Display(Name = "Equipamento alugado")]
        public bool STAlugado { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a data de aquisição do equipamento!")]
        [Display(Name = "Data de aquisição")]
        public DateTime DTCompra { get; set; }
    }
}