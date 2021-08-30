using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Dio.Localiza.Frotas.API.Configuration
{
    /// <summary>
    /// Configuração do swagger
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Configuração do swagger
        /// </summary>
        /// <param name="services">services</param>
        /// <returns>services</returns>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                var documentationXmlPath = Path.Combine(AppContext.BaseDirectory, "API.xml");
                c.IncludeXmlComments(documentationXmlPath);
            });

            return services;
        }
    }
}