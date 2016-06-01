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

        public override List<Gado> GadosParaInseminar()
        {
            var listaGadosInseminacao = db.Gados.ToList();

            listaGadosInseminacao = listaGadosInseminacao.
                Where(gado => gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoInseminacao.Month == DateTime.Now.Month).ToList();

            return listaGadosInseminacao;
        }

        public override List<Gado> GadosParaTrazerParaProcriar()
        {
            var listaGadosTrazerProcriar = db.Gados.ToList();

            listaGadosTrazerProcriar = listaGadosTrazerProcriar.
                Where(gado => gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoTrazerProcriacao.Month == DateTime.Now.Month).ToList();

            return listaGadosTrazerProcriar;
        }

        public override List<Gado> GadosParaProcriar()
        {
            var listaGadosProcriar = db.Gados.ToList();

            listaGadosProcriar = listaGadosProcriar.
                Where(gado => gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoProcriacao.Month == DateTime.Now.Month).ToList();

            return listaGadosProcriar;
        }

        public override List<Gado> GadosParaDesamamentar()
        {
            var listaGadosDesamamentar = db.Gados.ToList();

            listaGadosDesamamentar = listaGadosDesamamentar.
                Where(gado => gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoDesamamentacao.Month == DateTime.Now.Month).ToList();

            return listaGadosDesamamentar;
        }
    }
}