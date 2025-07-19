using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Project.Core.Application.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(AutoMapperConfig).Assembly));
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}