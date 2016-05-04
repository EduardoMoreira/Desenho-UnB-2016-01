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
            var vacas = new List<Vaca>
            {
            new Vaca{NRBrinco = 1, TPSexo = Sexo.F, DTNascimento = DateTime.Parse("2005-09-01")},
            new Vaca{NRBrinco = 2, TPSexo = Sexo.F, DTNascimento = DateTime.Parse("2005-10-01")},
            new Vaca{NRBrinco = 3, TPSexo = Sexo.M, DTNascimento = DateTime.Parse("2006-02-01")},
            new Vaca{NRBrinco = 4, TPSexo = Sexo.M, DTNascimento = DateTime.Parse("2007-03-01")},
            new Vaca{NRBrinco = 5, TPSexo = Sexo.M, DTNascimento = DateTime.Parse("2008-03-01")},
            new Vaca{NRBrinco = 6, TPSexo = Sexo.F, DTNascimento = DateTime.Parse("2009-03-01")},
            new Vaca{NRBrinco = 7, TPSexo = Sexo.F, DTNascimento = DateTime.Parse("2010-03-01")},
            new Vaca{NRBrinco = 8, TPSexo = Sexo.F, DTNascimento = DateTime.Parse("2011-03-01")}
            };

            vacas.ForEach(s => context.Vacas.Add(s));
            context.SaveChanges();
            
        }
    }
}