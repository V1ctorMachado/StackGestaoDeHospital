using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class PacienteConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.Property(paciente => paciente.NumeroCarteirinha)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(paciente => paciente.PlanoSaude)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
