using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Vacina
    {
        [Key]
        public int CDVacina { get; set; }

        [Display(Name = "Data da Aplicação")]
        [DataType(DataType.Date)]
        public DateTime DTAplicacao { get; set; }

        [Display(Name = "Descrição da Vacina")]
        public string DEVacina { get; set; }

        [Display(Name = "Observação da Aplicação")]
        public string DEObservacao { get; set; }

        public virtual Funcionario Funcionario { get; set; }
        public virtual Gado Gado { get; set; }
    }
}