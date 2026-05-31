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
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Leito> Leitos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Internacao> Internacoes { get; set; }
        public DbSet<Prescricao> Prescricoes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<Exame> Exames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("GESTAOHOSPITAL");

            base.OnModelCreating(modelBuilder);

            // Aplicar configurações das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
        }
    }
}
