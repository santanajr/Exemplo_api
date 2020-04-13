using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Payment.Infra.FireBase
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            //data context
            //services.AddSingleton<IFirebase_interface, FireBaseClass>();


            return services;

        }
    }
}

