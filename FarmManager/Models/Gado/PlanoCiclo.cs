using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class PlanoCiclo
    {
        public IList<IList<Gado>> RetornaListaGados()
        {
            IList<IList<Gado>> listaGados = new List<IList<Gado>>();

            var listaGadosInseminacao = GadosParaInseminar();
            listaGados.Add(listaGadosInseminacao);

            var listaGadosTrazerParaProcriacao = GadosParaTrazerParaProcriar();
            listaGados.Add(listaGadosTrazerParaProcriacao);

            var listaGadosProcriacao = GadosParaProcriar();
            listaGados.Add(listaGadosProcriacao);

            var listaGadosDesamamentacao = GadosParaDesamamentar();
            listaGados.Add(listaGadosDesamamentacao);

            return listaGados;
        }

        public abstract List<Gado> GadosParaInseminar();

        public abstract List<Gado> GadosParaTrazerParaProcriar();

        public abstract List<Gado> GadosParaProcriar();

        public abstract List<Gado> GadosParaDesamamentar();
    }
}