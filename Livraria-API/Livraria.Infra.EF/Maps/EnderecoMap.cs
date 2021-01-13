using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Logradouro)
                .HasColumnName("Logradouro");

            builder.Property(x => x.Numero)
                .HasColumnName("Numero");

            builder.Property(x => x.CEP)
                .HasColumnName("CEP");

            builder.Property(x => x.CidadeId)
                .HasColumnName("CidadeId");

            builder.HasOne(x => x.Cidade)
                .WithOne()
                .HasPrincipalKey<Cidade>(x => x.Id)
                .HasForeignKey<Endereco>(x => x.CidadeId);
        }
    }
}