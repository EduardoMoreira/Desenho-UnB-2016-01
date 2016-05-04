using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManager.Models
{
    public enum Sexo
    {
        M, F
    }
    public class Vaca
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NRBrinco { get; set; }
        public DateTime DTNascimento { get; set; }
        public Sexo TPSexo { get; set; }
        public DateTime? DTInseminacao { get; set; }
        public DateTime? DTDesamamentacao { get; set; }
        public DateTime? DTProcriacao { get; set; }
    }
}