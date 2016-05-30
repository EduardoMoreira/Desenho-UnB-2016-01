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

        [Required(ErrorMessage = "Digite a descrição do equipamento rural!")]
        [Display(Name = "Descrição")]
        public string DEEquipamentoRural { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        [Required(ErrorMessage = "Digite o valor de compra do equipamento!")]
        [Display(Name = "Valor de Compra")]
        public decimal VLCompra { get; set; }

        [Required(ErrorMessage = "Indique se é alugado!")]
        [Display(Name = "Alugado?")]
        public bool STAlugado { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Digite a data de compra do equipamento!")]
        [Display(Name = "Data de Compra")]
        public DateTime DTCompra { get; set; }
    }
}