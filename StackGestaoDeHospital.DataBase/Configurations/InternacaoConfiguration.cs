using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class InternacaoConfiguration : IEntityTypeConfiguration<Internacao>
    {
        public void Configure(EntityTypeBuilder<Internacao> builder)
        {
            builder.ToTable("Internacao");

            builder.HasKey(internacao => internacao.Id);
            builder.Property(internacao => internacao.Id).ValueGeneratedOnAdd();

            builder.Property(internacao => internacao.DataEntrada).IsRequired();

            builder.Property(internacao => internacao.Motivo)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(internacao => internacao.Observacoes)
                .HasMaxLength(1000);

            builder.Property(internacao => internacao.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.HasOne(internacao => internacao.Paciente)
                .WithMany()
                .HasForeignKey(internacao => internacao.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
