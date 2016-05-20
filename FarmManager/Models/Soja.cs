using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Soja
    {
        [Key]
        public int CDSoja { get; set; }

        [Display(Name = "Quantidade")]
        public int NRQuantidade { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Atualização")]
        public DateTime DTAtualizacao { get; set; }
    }
}