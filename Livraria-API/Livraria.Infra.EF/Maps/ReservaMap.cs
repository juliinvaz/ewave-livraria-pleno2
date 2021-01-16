using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Data)
                .HasColumnName("Data");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId");

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Reservas)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.LivroId)
                .HasColumnName("LivroId");

            builder.HasOne(x => x.Livro)
                .WithOne()
                .HasPrincipalKey<Livro>(x => x.Id)
                .HasForeignKey<Reserva>(x => x.LivroId);

             builder.Property(x => x.SituacaoId)
                .HasColumnName("SituacaoId");

            builder.HasOne(x => x.Situacao)
                .WithOne()
                .HasPrincipalKey<ReservaSituacao>(x => x.Id)
                .HasForeignKey<Reserva>(x => x.SituacaoId);

        }
    }
}
