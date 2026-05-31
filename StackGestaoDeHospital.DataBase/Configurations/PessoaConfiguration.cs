using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.UseTptMappingStrategy();
            builder.ToTable("Pessoa");

            builder.HasKey(pessoa => pessoa.Id);
            builder.Property(pessoa => pessoa.Id).ValueGeneratedOnAdd();

            builder.Property(pessoa => pessoa.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(pessoa => pessoa.Sobrenome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(pessoa => pessoa.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.HasIndex(pessoa => pessoa.CPF).IsUnique();

            builder.Property(pessoa => pessoa.DataNascimento).IsRequired();

        }
    }
}
