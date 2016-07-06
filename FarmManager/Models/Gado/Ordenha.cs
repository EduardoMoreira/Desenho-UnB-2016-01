using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Ordenha
    {
        [Key]
        public int CDOrdenha { get; set; }
        
        [Display(Name = "Quantidade de leite (litros)")]
        public int VLLeite { get; set; }

        [Required(ErrorMessage = "Digite a data de ordenha!")]
        [Display(Name = "Data da Ordenha")]
        [DataType(DataType.Date)]
        public DateTime DTOrdenha { get; set; }

        public virtual Gado Gado { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}