using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManager.Models
{
    public enum Sexo
    {
        Masculino, Feminino
    }
    public class Vaca
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Número do Brinco")]
        public int NRBrinco { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DTNascimento { get; set; }
        [Display(Name = "Sexo")]
        public Sexo TPSexo { get; set; }
        [Display(Name = "Data de Inseminação")]
        public DateTime? DTInseminacao { get; set; }
        [Display(Name = "Data de Desamamentação")]
        public DateTime? DTDesamamentacao { get; set; }
        [Display(Name = "Data de Procriação")]
        public DateTime? DTProcriacao { get; set; }
    }
}