using Project.Core.Application.Configurations;
using Project.Core.Application.Services;
using Project.Core.Infraestructure.Repositories;

namespace Project.Core.Api.Configurations
{
    public static class DependencyInjectionService
    {
        public static void AddDependencyInjectionService(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddScoped<FornecedorContatoService>();
            services.AddScoped<FornecedorContatoRepository>();
            services.AddScoped<OpcionalService>();
            services.AddScoped<OpcionalRepository>();
            services.AddScoped<OpcionalVeiculoService>();
            services.AddScoped<OpcionalVeiculoRepository>();
            services.AddScoped<PacoteService>();
            services.AddScoped<PacoteRepository>();
            services.AddScoped<PortalService>();
            services.AddScoped<PortalRepository>();
            services.AddScoped<VeiculoService>();
            services.AddScoped<VeiculoRepository>();
            services.AddScoped<VeiculoCorService>();
            services.AddScoped<VeiculoCorRepository>();
            services.AddScoped<VeiculoImagemService>();
            services.AddScoped<VeiculoImagemRepository>();
            services.AddScoped<VeiculoMarcaService>();
            services.AddScoped<VeiculoMarcaRepository>();
            services.AddScoped<VeiculoPortalPacoteService>();
            services.AddScoped<VeiculoPortalPacoteRepository>();

            services.AddAutoMapper();
        }
    }
}