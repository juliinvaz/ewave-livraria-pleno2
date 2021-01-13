using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Data)
                .HasColumnName("Data");

            builder.Property(x => x.DataDevolucao)
                .HasColumnName("DataDevolucao");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("UsuarioId");

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Emprestimos)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.LivroId)
                .HasColumnName("LivroId");

            builder.HasOne(x => x.Livro)
                .WithOne()
                .HasPrincipalKey<Livro>(x => x.Id)
                .HasForeignKey<Emprestimo>(x => x.LivroId);

        }
    }
}
