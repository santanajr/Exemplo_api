using Microsoft.Extensions.DependencyInjection;
using Payment.Domain.Interface;
using Payment.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddDomain(this IServiceCollection services )
        {
            //data context
            services.AddScoped<PaymentDataContext , PaymentDataContext >();

            services.AddTransient<IEstabelecimentoDomainService , EstabelecimentoDomainService  >();

            return services;
        
        }
    }
}
