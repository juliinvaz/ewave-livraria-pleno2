using Livraria.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Livraria.Application.Modules
{
    public static class DataContextModule
    {
        public static void DataContextModuleRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Livraria");

            services.AddDbContext<DataContext>(opt => {
                opt
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
            });

            services.AddScoped<DataContext>();
        }
    }
}