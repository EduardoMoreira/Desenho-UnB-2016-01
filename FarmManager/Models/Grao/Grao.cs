using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class Grao
    {
        [Key]
        public int CDGrao { get; set; }

        [Required(ErrorMessage = "Digite a quantidade disponível!")]
        [Display(Name = "Quantidade (kg)")]
        public int NRQuantidade { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Atualização")]
        public DateTime? DTAtualizacao { get; set; }

        public virtual void update(int quantidade)
        {
            throw new Exception("Função não implementada");
        }
    }
}