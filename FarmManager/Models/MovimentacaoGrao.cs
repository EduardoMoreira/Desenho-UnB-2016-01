using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public enum TipoGrao
    {
        Milho, Soja
    }

    public enum TipoEntradaSaida
    {
        Entrada, Saida
    }

    public class MovimentacaoGrao : IMovimentacaoGrao
    {
        [Key]
        public int CDMovimentacaoGrao { get; set; }

        [Display(Name = "Tipo de Grão")]
        public TipoGrao TPGrao { get; set; }

        [Display(Name = "Descrição")]
        public string DEMovimentacaoGrao { get; set; }

        [Display(Name = "Entrada/Saída")]
        public TipoEntradaSaida TPEntradaSaida { get; set; }

        [Display(Name = "Quantidade (kg)")]
        public int NRQuantidade { get; set; }

        [NotMapped]
        private List<Grao> listaGraos = new List<Grao>();

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