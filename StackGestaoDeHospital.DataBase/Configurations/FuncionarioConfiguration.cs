using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.Property(funcionario => funcionario.Matricula)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(funcionario => funcionario.Matricula).IsUnique();

            builder.Property(funcionario => funcionario.Salario)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}