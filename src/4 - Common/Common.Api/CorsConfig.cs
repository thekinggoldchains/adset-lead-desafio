using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Common.Api
{
    public static class CorsConfig
    {
        public static void AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var origins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("MyOrigins",
                    builder =>
                        builder
                            .WithOrigins(origins)
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });
        }

        public static void UseCorsConfiguration(this WebApplication app)
        {
            app.UseCors("MyOrigins");
        }
    }
}
