using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class InstituicaoEnsinoMap : IEntityTypeConfiguration<InstituicaoEnsino>
    {
        public void Configure(EntityTypeBuilder<InstituicaoEnsino> builder)
        {
            builder.ToTable("InstituicaoEnsino");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.CNPJ)
                .HasColumnName("CNPJ");

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<InstituicaoEnsinoSituacao>(x => x.Id)
                .HasForeignKey<InstituicaoEnsino>(x => x.SituacaoId);

            builder.Property(x => x.EnderecoId)
                .HasColumnName("EnderecoId");

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasPrincipalKey<Endereco>(x => x.Id)
                .HasForeignKey<InstituicaoEnsino>(x => x.EnderecoId);

        }
    }
}
