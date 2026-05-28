using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class PrescricaoConfiguration : IEntityTypeConfiguration<Prescricao>
    {
        public void Configure(EntityTypeBuilder<Prescricao> builder)
        {
            builder.ToTable("Prescricao");

            builder.HasKey(prescricao => prescricao.Id);
            builder.Property(prescricao => prescricao.Id).ValueGeneratedOnAdd();

            builder.Property(prescricao => prescricao.DataPrescricao).IsRequired();

            builder.Property(prescricao => prescricao.Dosagem)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prescricao => prescricao.Frequencia)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(prescricao => prescricao.Duracao).HasMaxLength(50);
            builder.Property(prescricao => prescricao.Observacoes).HasMaxLength(500);

            builder.HasOne(prescricao => prescricao.Atendimento)
                .WithMany()
                .HasForeignKey(prescricao => prescricao.AtendimentoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prescricao => prescricao.Medicamento)
                .WithMany(medicamento => medicamento.Prescricoes)
                .HasForeignKey(prescricao => prescricao.MedicamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prescricao => prescricao.Medico)
                .WithMany()
                .HasForeignKey(prescricao => prescricao.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}