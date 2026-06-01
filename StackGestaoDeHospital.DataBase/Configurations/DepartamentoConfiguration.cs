using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("Departamento");

            builder.HasKey(Departamento => Departamento.Id);

            builder.Property(Departamento => Departamento.Id)
                .ValueGeneratedOnAdd();

            builder.Property(Departamento => Departamento.Nome)
                .HasMaxLength(100)
                .IsRequired();

 

        }
    }
}
