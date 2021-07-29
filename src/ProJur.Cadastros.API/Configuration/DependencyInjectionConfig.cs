using Microsoft.Extensions.DependencyInjection;
using ProJur.Cadastros.Domain;
using DomainService = ProJur.Cadastros.Domain.Service;
using ProJur.Cadastros.Infra;
using ProJur.Cadastros.Infra.Data.Repositories;
using AppService = ProJur.Cadastros.Aplication.Services;

namespace ProJur.Cadastros.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuarioContext>();

            services.AddScoped<DomainService.IUsuarioService, DomainService.UsuarioService>();
            services.AddScoped<AppService.IUsuarioService, AppService.UsuarioService>();
        }
    }
}
