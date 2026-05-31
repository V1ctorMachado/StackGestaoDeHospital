using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class EspecialidadeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("Especialidade");

            builder.HasKey(especialidade => especialidade.Id);
            builder.Property(especialidade => especialidade.Id).ValueGeneratedOnAdd();

            builder.Property(especialidade => especialidade.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}