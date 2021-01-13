using Livraria.Infra.Data;
using Livraria.Infra.EF;
using Livraria.Infra.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Livraria.Application.Modules
{
    public static class RepositoryModule
    {
        public static void RepositoryModuleModuleRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var repositories = typeof(InstituicaoEnsinoRepository).Assembly.GetTypes()
             .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>) && !t.IsAbstract));

            foreach (var repository in repositories)
            {
                services.AddScoped(repository.GetInterfaces()[1], repository);
            }
        }
    }
}