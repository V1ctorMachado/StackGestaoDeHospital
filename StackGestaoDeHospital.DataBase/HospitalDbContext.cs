using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.DataBase.Configurations;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GESTAOHOSPITAL");

            base.OnModelCreating(modelBuilder);

            // Aplicar configurações das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
        }
    }
}
