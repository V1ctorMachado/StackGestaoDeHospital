using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class EnfermeiroConfiguration : IEntityTypeConfiguration<Enfermeiro>
    {
        public void Configure(EntityTypeBuilder<Enfermeiro> builder)
        {
            builder.ToTable("Enfermeiro");

            builder.Property(enfermeiro => enfermeiro.CRE)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(enfermeiro => enfermeiro.CRE).IsUnique();
        }
    }
}
