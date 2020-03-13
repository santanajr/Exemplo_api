using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Maps
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Bandeira).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)") ;
            builder.Property(x => x.DataVencimento).IsRequired().HasColumnType("Date");
            builder.Property(x => x.NumeroCartao).IsRequired().HasMaxLength(30).HasColumnType("varchar(30)");
            //builder.Property(x => x.NomeEstabelecimento).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
        }

    }
}

/*
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
*/