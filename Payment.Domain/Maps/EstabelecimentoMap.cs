using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Maps
{
    public class EstabelecimentoMap : IEntityTypeConfiguration<Estabelecimento> 
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("Estabelecimento");
            builder.HasKey(x => x.IdEstabelecimento);
            builder.Property(x => x.NomeEstabelecimento).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
        }
    }
}
