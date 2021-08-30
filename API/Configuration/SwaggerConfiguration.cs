using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Dio.Localiza.Frotas.API.Configuration
{
    public static class SwaggerConfiguration
    {
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