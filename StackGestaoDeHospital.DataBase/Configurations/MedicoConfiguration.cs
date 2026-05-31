using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");

            builder.Property(medico => medico.CRM)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(medico => medico.CRM)
                .IsUnique();

            builder.HasMany(medico => medico.Especialidades)
                .WithMany()
                .UsingEntity("MedicoEspecialidade");
        }
    }
}
