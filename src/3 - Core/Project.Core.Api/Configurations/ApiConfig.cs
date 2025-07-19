using Common.Api;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Project.Core.Infraestructure.Context;

namespace Project.Core.Api.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<DbContextCore>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddCorsConfiguration(configuration);

            services.AddDependencyInjectionConfiguration(configuration);

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddAuthorizationConfiguration();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerConfiguration();

            services.AddHealthCheck(configuration, env);
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerSetup();
            }

            app.UseCorsConfiguration();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();
        }
    }
}