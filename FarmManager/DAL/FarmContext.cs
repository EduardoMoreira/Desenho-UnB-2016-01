﻿using FarmManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FarmManager.DAL
{
    public class FarmContext : DbContext
    {

        public FarmContext()
            : base("FarmContext")
        {
        }

        public DbSet<Vaca> Vacas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<FarmManager.Models.TerraPlantio> TerrasPlantios { get; set; }

        public System.Data.Entity.DbSet<FarmManager.Models.Piquete> Piquetes { get; set; }

        public System.Data.Entity.DbSet<FarmManager.Models.Pasto> Pastos { get; set; }

        public System.Data.Entity.DbSet<FarmManager.Models.TerraNua> TerrasNuas { get; set; }

        public System.Data.Entity.DbSet<FarmManager.Models.EquipamentoRural> EquipamentosRurais { get; set; }

        public System.Data.Entity.DbSet<FarmManager.Models.Funcionario> Funcionarios { get; set; }
    }
}