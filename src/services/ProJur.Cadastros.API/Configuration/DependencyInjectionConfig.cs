using Microsoft.Extensions.DependencyInjection;
using ProJur.Cadastros.Domain;
using DomainService = ProJur.Cadastros.Domain.Services;
using ProJur.Cadastros.Infra;
using ProJur.Cadastros.Infra.Data.Repositories;
using AppService = ProJur.Cadastros.Aplication.Services;
using ProJur.Core.Communication;
using MediatR;
using ProJur.Cadastros.Aplication.Commands;
using FluentValidation.Results;
using ProJur.Cadastros.Aplication.Queries;

namespace ProJur.Cadastros.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<UsuarioContext>();

            services.AddScoped<DomainService.IUsuarioService, DomainService.UsuarioService>();
            services.AddScoped<AppService.IUsuarioService, AppService.UsuarioService>();

            services.AddScoped<IRequestHandler<AdicionarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<DeletarUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();

            services.AddScoped<IUsuarioQueries, UsuarioQueries>();
        }
    }
}
