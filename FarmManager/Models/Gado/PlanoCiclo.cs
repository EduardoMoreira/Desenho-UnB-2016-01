using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class PlanoCiclo
    {
        public IList<IList<Gado>> RetornaListaVacas()
        {
            IList<IList<Gado>> listaVacas = new List<IList<Gado>>();

            var listaVacasInseminacao = VacasParaInseminar();
            listaVacas.Add(listaVacasInseminacao);

            var listaVacasTrazerParaProcriacao = VacasParaTrazerParaProcriar();
            listaVacas.Add(listaVacasTrazerParaProcriacao);

            var listaVacasProcriacao = VacasParaProcriar();
            listaVacas.Add(listaVacasProcriacao);

            var listaVacasDesamamentacao = VacasParaDesamamentar();
            listaVacas.Add(listaVacasDesamamentacao);

            return listaVacas;
        }

        public abstract List<Gado> VacasParaInseminar();

        public abstract List<Gado> VacasParaTrazerParaProcriar();

        public abstract List<Gado> VacasParaProcriar();

        public abstract List<Gado> VacasParaDesamamentar();
    }
}