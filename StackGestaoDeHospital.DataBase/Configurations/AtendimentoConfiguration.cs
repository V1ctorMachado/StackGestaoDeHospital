using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class AtendimentoConfiguration : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimento");

            builder.HasKey(atendimento => atendimento.Id);

            builder.Property(atendimento => atendimento.Id)
                .ValueGeneratedOnAdd();

            builder.Property(atendimento => atendimento.Data)
                .IsRequired();

            builder.Property(atendimento => atendimento.Queixa)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(atendimento => atendimento.Diagnostico)
                .HasMaxLength(1000);

            builder.Property(atendimento => atendimento.Status)
                .HasDefaultValue(StatusAtendimentoEnum.Aberto)
                .IsRequired();

            builder.HasOne(atendimento => atendimento.Especialidade)
                .WithMany()
                .HasForeignKey("EspecialidadeId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(atendimento => atendimento.Enfermeiro)
                .WithMany()
                .HasForeignKey("EnfermeiroId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(atendimento => atendimento.Medico)
                .WithMany()
                .HasForeignKey("MedicoId")
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(atendimento => atendimento.Paciente)
                .WithMany()
                .HasForeignKey("PacienteId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(atendimento => atendimento.Departamento)
                .WithMany()
                .HasForeignKey("DepartamentoId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
