using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class PlanoCicloSemanal : PlanoCiclo
    {
        FarmContext db = new FarmContext();

        public override IList<IList<Vaca>> RetornaListaVacas()
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

        private List<Vaca> VacasParaInseminar()
        {
            var listaVacasInseminacao = db.Vacas.ToList();

            listaVacasInseminacao = listaVacasInseminacao.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoInseminacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoInseminacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasInseminacao;
        }

        private List<Vaca> VacasParaTrazerParaProcriar()
        {
            var listaVacasTrazerProcriar = db.Vacas.ToList();

            listaVacasTrazerProcriar = listaVacasTrazerProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoTrazerProcriacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoTrazerProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasTrazerProcriar;
        }

        private List<Vaca> VacasParaProcriar()
        {
            var listaVacasProcriar = db.Vacas.ToList();

            listaVacasProcriar = listaVacasProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoProcriacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasProcriar;
        }

        private List<Vaca> VacasParaDesamamentar()
        {
            var listaVacasDesamamentar = db.Vacas.ToList();

            listaVacasDesamamentar = listaVacasDesamamentar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoDesamamentacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoDesamamentacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasDesamamentar;
        }
    }
}