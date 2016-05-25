using FarmManager.Models;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<RegisterViewModel> Usuarios { get; set; }

        public DbSet<Vaca> Vacas { get; set; }

        public DbSet<TerraPlantio> TerrasPlantios { get; set; }

        public DbSet<Piquete> Piquetes { get; set; }

        public DbSet<Pasto> Pastos { get; set; }

        public DbSet<TerraNua> TerrasNuas { get; set; }

        public DbSet<EquipamentoRural> EquipamentosRurais { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}