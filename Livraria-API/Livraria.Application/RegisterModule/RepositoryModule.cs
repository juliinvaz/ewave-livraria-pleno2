using Livraria.Infra.Data;
using Livraria.Infra.EF;
using Livraria.Infra.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Livraria.Application.Modules
{
    public static class RepositoryModule
    {
        public static void RepositoryModuleRegister(this IServiceCollection services)
        {
            var repositories = Assembly.GetAssembly(typeof(InstituicaoEnsinoRepository))
                .GetTypes().Where(x => x.Name.EndsWith("Repository"))
                .ToDictionary(t => t.GetInterfaces()[1], t => t);

            foreach (var item in repositories)
            {
                services.AddScoped(item.Key, item.Value);
            }
        }
    }
}