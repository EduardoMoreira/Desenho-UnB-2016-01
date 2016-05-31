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

        public override List<Vaca> VacasParaInseminar()
        {
            var listaVacasInseminacao = db.Vacas.ToList();

            listaVacasInseminacao = listaVacasInseminacao.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoInseminacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoInseminacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasInseminacao;
        }

        public override List<Vaca> VacasParaTrazerParaProcriar()
        {
            var listaVacasTrazerProcriar = db.Vacas.ToList();

            listaVacasTrazerProcriar = listaVacasTrazerProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoTrazerProcriacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoTrazerProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasTrazerProcriar;
        }

        public override List<Vaca> VacasParaProcriar()
        {
            var listaVacasProcriar = db.Vacas.ToList();

            listaVacasProcriar = listaVacasProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoProcriacao.Day >= DateTime.Now.Day &&
                              vaca.DTPrevisaoProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaVacasProcriar;
        }

        public override List<Vaca> VacasParaDesamamentar()
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