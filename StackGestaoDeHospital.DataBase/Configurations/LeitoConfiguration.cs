using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackGestaoDeHospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackGestaoDeHospital.DataBase.Configurations
{
    public class LeitoConfiguration : IEntityTypeConfiguration<Leito>
    {
        public void Configure(EntityTypeBuilder<Leito> builder)
        {
            builder.ToTable("Leito");

            builder.HasKey(leito => leito.Id);
            builder.Property(leito => leito.Id).ValueGeneratedOnAdd();

            builder.Property(leito => leito.Numero)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(leito => leito.Tipo)
                .HasConversion<int>() 
                .IsRequired();

            builder.Property(leito => leito.Ocupado).IsRequired();

        }
    }
}