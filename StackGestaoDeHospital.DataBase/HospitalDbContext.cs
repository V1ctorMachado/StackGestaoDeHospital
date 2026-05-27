using Microsoft.EntityFrameworkCore;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais do modelo podem ser adicionadas aqui
        }
    }
}
