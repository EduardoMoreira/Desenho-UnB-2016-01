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

        public override List<Gado> GadosParaInseminar()
        {
            var listaGadosInseminacao = db.Gados.ToList();

            listaGadosInseminacao = listaGadosInseminacao.
                Where(gado => gado.STAtivo == STAtivo.Sim &&
                              gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoInseminacao.Day >= DateTime.Now.Day &&
                              gado.DTPrevisaoInseminacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaGadosInseminacao;
        }

        public override List<Gado> GadosParaTrazerParaProcriar()
        {
            var listaGadosTrazerProcriar = db.Gados.ToList();

            listaGadosTrazerProcriar = listaGadosTrazerProcriar.
                Where(gado => gado.STAtivo == STAtivo.Sim &&
                              gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoTrazerProcriacao.Day >= DateTime.Now.Day &&
                              gado.DTPrevisaoTrazerProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaGadosTrazerProcriar;
        }

        public override List<Gado> GadosParaProcriar()
        {
            var listaGadosProcriar = db.Gados.ToList();

            listaGadosProcriar = listaGadosProcriar.
                Where(gado => gado.STAtivo == STAtivo.Sim &&
                              gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoProcriacao.Day >= DateTime.Now.Day &&
                              gado.DTPrevisaoProcriacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaGadosProcriar;
        }

        public override List<Gado> GadosParaDesamamentar()
        {
            var listaGadosDesamamentar = db.Gados.ToList();

            listaGadosDesamamentar = listaGadosDesamamentar.
                Where(gado => gado.STAtivo == STAtivo.Sim &&
                              gado.DTDesamamentacao != null &&
                              gado.DTDesamamentacao != DateTime.MinValue &&
                              gado.DTPrevisaoDesamamentacao.Day >= DateTime.Now.Day &&
                              gado.DTPrevisaoDesamamentacao.Day < DateTime.Now.AddDays(7).Day).ToList();

            return listaGadosDesamamentar;
        }
    }
}