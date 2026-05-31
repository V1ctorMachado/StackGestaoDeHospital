using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class ExameConfiguration : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");

            builder.HasKey(exame => exame.Id);
            builder.Property(exame => exame.Id).ValueGeneratedOnAdd();

            builder.Property(exame => exame.Tipo)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(exame => exame.DataSolicitacao).IsRequired();

            builder.Property(exame => exame.Resultado).HasMaxLength(2000);

            builder.Property(exame => exame.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.HasOne(exame => exame.Atendimento)
                .WithMany()
                .HasForeignKey(exame => exame.AtendimentoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

