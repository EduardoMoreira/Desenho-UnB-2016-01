using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public abstract class PlanoCiclo
    {
        public IList<IList<Vaca>> RetornaListaVacas()
        {
            IList<IList<Vaca>> listaVacas = new List<IList<Vaca>>();

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

        public abstract List<Vaca> VacasParaInseminar();

        public abstract List<Vaca> VacasParaTrazerParaProcriar();

        public abstract List<Vaca> VacasParaProcriar();

        public abstract List<Vaca> VacasParaDesamamentar();
    }
}