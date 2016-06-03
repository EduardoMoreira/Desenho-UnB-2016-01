using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManager.Models
{
    public enum Sexo
    {
        Masculino, Feminino
    }
    public class Gado
    {
        [Key]
        [Required(ErrorMessage = "Digite o número do brinco do animal!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Número do Brinco")]
        public int NRBrinco { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento do animal!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DTNascimento { get; set; }

        [Display(Name = "Sexo")]
        public Sexo TPSexo { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Data de Inseminação")]
        public DateTime? DTInseminacao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Desamamentação")]
        public DateTime? DTDesamamentacao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Procriação")]
        public DateTime? DTProcriacao { get; set; }

        [Display(Name = "O animal existe atualmente na propriedade?")]
        public bool STAtivo { get; set; }

        public DateTime DTPrevisaoInseminacao
        {
            get
            {
                if (DTProcriacao != null)
                    return Convert.ToDateTime(DTProcriacao).AddDays(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DiasEntreProcriacaoInseminacao"]));
                else
                    return Convert.ToDateTime(DTNascimento).AddMonths(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MesesEntreNascimentoInseminacao"]));
            }
        }

        public DateTime DTPrevisaoTrazerProcriacao
        {
            get
            {
                return Convert.ToDateTime(DTInseminacao).AddDays(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DiasEntreInseminacaoTrazerProcriacao"]));
            }
        }

        public DateTime DTPrevisaoProcriacao
        {
            get
            {
                return Convert.ToDateTime(DTInseminacao).AddDays(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DiasEntreInseminacaoProcriacao"]));
            }
        }

        public DateTime DTPrevisaoDesamamentacao
        {
            get
            {
                return Convert.ToDateTime(DTProcriacao).AddDays(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DiasEntreProcriacaoDesamamentacao"]));
            }
        }
    }
}