using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class ReservaSituacaoMap : IEntityTypeConfiguration<ReservaSituacao>
    {
        public void Configure(EntityTypeBuilder<ReservaSituacao> builder)
        {
            builder.ToTable("ReservaSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}