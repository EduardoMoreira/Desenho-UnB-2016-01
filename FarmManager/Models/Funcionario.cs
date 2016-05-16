using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class Funcionario
    {
        [Key]
        public int CDFuncionario { get; set; }

        [Required(ErrorMessage = "Digite o nome do funcionário!")]
        [Display(Name = "Nome")]
        public string NOFuncionario { get; set; }

        [Required(ErrorMessage = "Digite o salário do funcionário!")]
        [Display(Name = "Salário (R$)")]
        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal VLSalario { get; set; }

        [Required(ErrorMessage = "Digite a data de contratação do funcionário!")]
        [Display(Name = "Data de Contratação")]
        [DataType(DataType.Date)]
        public DateTime DTContratacao { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do funcionário!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DTNascimento { get; set; }
    }
}