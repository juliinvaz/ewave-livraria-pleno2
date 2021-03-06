﻿using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Infra.EF.Maps
{
    public class InstituicaoEnsinoSituacaoMap : IEntityTypeConfiguration<InstituicaoEnsinoSituacao>
    {
        public void Configure(EntityTypeBuilder<InstituicaoEnsinoSituacao> builder)
        {
            builder.ToTable("InstituicaoEnsinoSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome");
        }
    }
}