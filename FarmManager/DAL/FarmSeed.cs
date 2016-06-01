using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FarmManager.Models;

namespace FarmManager.DAL
{
    public class FarmSeed : System.Data.Entity.DropCreateDatabaseIfModelChanges<FarmContext>
    {
        protected override void Seed(FarmContext context)
        {
            var gados = new List<Gado>
            {
                new Gado{NRBrinco = 1, TPSexo = Sexo.Feminino, DTNascimento = DateTime.Parse("2005-09-01"), DTDesamamentacao = DateTime.Parse("2016-05-01"), STAtivo = false},
                new Gado{NRBrinco = 2, TPSexo = Sexo.Feminino, DTNascimento = DateTime.Parse("2005-10-01"), DTDesamamentacao = DateTime.Parse("2016-04-10"), STAtivo = false},
                new Gado{NRBrinco = 3, TPSexo = Sexo.Masculino, DTNascimento = DateTime.Parse("2006-02-01"), DTDesamamentacao = DateTime.Parse("2016-04-15"), STAtivo = true},
                new Gado{NRBrinco = 4, TPSexo = Sexo.Masculino, DTNascimento = DateTime.Parse("2007-03-01")},
                new Gado{NRBrinco = 5, TPSexo = Sexo.Masculino, DTNascimento = DateTime.Parse("2008-03-01")},
                new Gado{NRBrinco = 6, TPSexo = Sexo.Feminino, DTNascimento = DateTime.Parse("2009-03-01")},
                new Gado{NRBrinco = 7, TPSexo = Sexo.Feminino, DTNascimento = DateTime.Parse("2010-03-01")},
                new Gado{NRBrinco = 8, TPSexo = Sexo.Feminino, DTNascimento = DateTime.Parse("2013-04-01")}
            };

            gados.ForEach(s => context.Gados.Add(s));

            var equipamentos = new List<EquipamentoRural>
            {
                new EquipamentoRural{CDEquipamentoRural = 1, DEEquipamentoRural = "Trator", DTCompra = DateTime.Parse("2012-03-01"), STAlugado = false, VLCompra = Convert.ToDecimal(1200.00)}
            };

            equipamentos.ForEach(s => context.EquipamentosRurais.Add(s));
            context.SaveChanges();

            var milhos = context.Milhos.ToList();
            if (milhos.Count == 0)
            {
                var milho = new Milho
                {
                    CDGrao = 1,
                    NRQuantidade = 0,
                    DTAtualizacao = DateTime.Now
                };

                context.Milhos.Add(milho);
            }

            var sojas = context.Sojas.ToList();
            if (sojas.Count == 0)
            {
                var soja = new Soja
                {
                    CDGrao = 1,
                    NRQuantidade = 0,
                    DTAtualizacao = DateTime.Now
                };

                context.Sojas.Add(soja);
            }

            var terrasFazenda = context.TerraFazenda.ToList();
            if (terrasFazenda.Count == 0)
            {
                var terra = new TerraFazenda
                {
                    NRHectares = 0
                };

                context.TerraFazenda.Add(terra);
            }
        }
    }
}