using Common.Orm;
using Common.Validation;

//using Common.Validation;
using Project.Core.Infraestructure.Context;
//using Common.Security.Identity;
//using Common.Storage;
//using Common.Storage.Azure;

namespace Project.Core.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();
            services.AddScoped<ValidationContract>();

            //services.Configure<AzureStorageConfiguration>(configuration.GetSection("StorageConfiguration"));
            //services.AddScoped<IStorage, AzureStorage>();

            //services.AddCurrentUserConfiguration();
            services.AddDependencyInjectionService();
        }
    }
}