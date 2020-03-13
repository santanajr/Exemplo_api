using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using Payment.Domain.Maps;

namespace Payment.Domain
{
      public class PaymentDataContext : DbContext 
    {
       // public DbSet<Cliente> DbCliente { get; set; }
       // public DbSet<Pagamento> DbPagamento { get; set; }
        public DbSet<Estabelecimento> DbEstabelecimentos { get; set; }
        public DbSet<Cartao> DbCartoes { get; set; }

        //public DbQuery<Estabelecimento> Qryestabelecimentos { get; set; }

        public PaymentDataContext(DbContextOptions<PaymentDataContext> options) : 
            base(options)
        { 
            
        
        }

        protected override void OnModelCreating( ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EstabelecimentoMap());
            builder.ApplyConfiguration(new CartaoMap());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=JRSANTANA\SQLEXPRESS;Initial Catalog=BDPayment;Integrated Security=True"); 
        //}


    }

}
