using FarmManager.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarmManager.Models
{
    public class PlanoCicloMensal : PlanoCiclo
    {
        FarmContext db = new FarmContext();

        public override List<Gado> VacasParaInseminar()
        {
            var listaVacasInseminacao = db.Vacas.ToList();

            listaVacasInseminacao = listaVacasInseminacao.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoInseminacao.Month == DateTime.Now.Month).ToList();

            return listaVacasInseminacao;
        }

        public override List<Gado> VacasParaTrazerParaProcriar()
        {
            var listaVacasTrazerProcriar = db.Vacas.ToList();

            listaVacasTrazerProcriar = listaVacasTrazerProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoTrazerProcriacao.Month == DateTime.Now.Month).ToList();

            return listaVacasTrazerProcriar;
        }

        public override List<Gado> VacasParaProcriar()
        {
            var listaVacasProcriar = db.Vacas.ToList();

            listaVacasProcriar = listaVacasProcriar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoProcriacao.Month == DateTime.Now.Month).ToList();

            return listaVacasProcriar;
        }

        public override List<Gado> VacasParaDesamamentar()
        {
            var listaVacasDesamamentar = db.Vacas.ToList();

            listaVacasDesamamentar = listaVacasDesamamentar.
                Where(vaca => vaca.DTDesamamentacao != null &&
                              vaca.DTDesamamentacao != DateTime.MinValue &&
                              vaca.DTPrevisaoDesamamentacao.Month == DateTime.Now.Month).ToList();

            return listaVacasDesamamentar;
        }
    }
}