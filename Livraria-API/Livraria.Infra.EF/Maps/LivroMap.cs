using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo");

            builder.Property(x => x.Genero)
                .HasColumnName("Genero");

            builder.Property(x => x.Autor)
                .HasColumnName("Autor");

            builder.Property(x => x.Sinopse)
                .HasColumnName("Sinopse");

            builder.Property(x => x.Capa)
                .HasColumnName("Capa");

            builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<LivroSituacao>(x => x.Id)
                .HasForeignKey<Livro>(x => x.SituacaoId);
        }
    }
}