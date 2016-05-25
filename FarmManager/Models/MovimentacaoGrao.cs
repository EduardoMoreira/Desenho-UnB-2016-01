using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class MovimentacaoGrao : IMovimentacaoGrao
    {
        [Key]
        public int CDMovimentacaoGrao { get; set; }
        
        [Display(Name = "Quantidade (kg)")]
        private int NRQuantidade { get; set; }

        [NotMapped]
        private List<Grao> listaGraos;

        public void attach(Grao grao)
        {
            listaGraos.Add(grao);
        }

        public void detach(Grao grao)
        {
            listaGraos.Remove(grao);
        }
        
        public void notify(int quantidade)
        {
            foreach (var grao in listaGraos)
            {
                grao.update(quantidade);
            }
        }
    }
}