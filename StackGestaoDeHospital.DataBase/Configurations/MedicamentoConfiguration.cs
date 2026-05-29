using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.ToTable("Medicamento");

            builder.HasKey(medicamento => medicamento.Id);
            builder.Property(medicamento => medicamento.Id).ValueGeneratedOnAdd();

            builder.Property(medicamento => medicamento.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(medicamento => medicamento.PrincipioAtivo).HasMaxLength(150);
            builder.Property(medicamento => medicamento.Apresentacao).HasMaxLength(100);
            builder.Property(medicamento => medicamento.Fabricante).HasMaxLength(100);
        }
    }
}
