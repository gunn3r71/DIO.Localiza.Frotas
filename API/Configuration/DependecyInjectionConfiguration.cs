using Dio.Localiza.Frotas.Domain.Interfaces;
using Dio.Localiza.Frotas.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dio.Localiza.Frotas.API.Configuration
{
    /// <summary>
    /// Resolve dependencias do projeto
    /// </summary>
    public static class DependecyInjectionConfiguration
    {
        /// <summary>
        /// Resolve dependencias do projeto
        /// </summary>
        /// <param name="services">Extensão de service</param>
        /// <returns>service</returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IVeiculoRepository, InMemoryVeiculoRepository>();
            return services;
        }
    }
}