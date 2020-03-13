using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IEstabelecimentoAppService, EstabelecimentoAppService>();
            
            return services;
        }

    }
}
