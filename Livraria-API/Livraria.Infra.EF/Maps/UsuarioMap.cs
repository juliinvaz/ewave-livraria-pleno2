using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");

            builder.Property(x => x.CPF)
                .HasColumnName("CPF");

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone");

            builder.Property(x => x.Email)
                .HasColumnName("Email");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<UsuarioSituacao>(x => x.Id)
                .HasForeignKey<Usuario>(x => x.SituacaoId);

            builder.Property(x => x.EnderecoId)
                .HasColumnName("EnderecoId");

            builder.HasOne(x => x.Endereco)
                .WithOne()
                .HasPrincipalKey<EnderecoMap>(x => x.Id)
                .HasForeignKey<Usuario>(x => x.SituacaoId);

            builder.Property(x => x.InstituicaoId)
                .HasColumnName("InstituicaoId");

            builder.HasOne(x => x.InstituicaoEnsino)
                .WithOne()
                .HasPrincipalKey<Domain.Models.InstituicaoEnsino>(x => x.Id)
                .HasForeignKey<Usuario>(x => x.InstituicaoId);

        }
    }
}
