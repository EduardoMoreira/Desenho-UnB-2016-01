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

        public DbSet<Vaca> Vacas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}