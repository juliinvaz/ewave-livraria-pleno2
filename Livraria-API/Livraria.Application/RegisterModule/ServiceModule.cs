using Livraria.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Livraria.Application.Modules
{
    public static class ServiceModule
    {
        public static void ServiceModuleRegister(this IServiceCollection services)
        {
            var livrariaServices = Assembly.GetAssembly(typeof(InstituicaoEnsinoService))
                .GetTypes().Where(x => x.Name.EndsWith("Service"))
                .ToDictionary(t => t.GetInterfaces()[0], t => t);

            foreach (var service in livrariaServices)
            {
                services.AddScoped(service.Key, service.Value);
            }
        }
    }
}