using Microsoft.Extensions.DependencyInjection;
using ProvadorVirtual.Aplicacao.Interfaces.Administracao;
using ProvadorVirtual.Aplicacao.Services;
using ProvadorVirtual.Nucleo.Interfaces.Repositorio.Administracao;
using ProvadorVirtual.Nucleo.Interfaces.Services.Administracao;
using ProvadorVirtual.Repositorio.Administracao;
using ProvadorVirtual.Servicos.Services.Administracao;

namespace ProvadorVirtual.Ioc
{
    public static class ModuleIOC
    {
        public static void RegisterModules(this IServiceCollection service)
        {
            RegisterTransient(service);
            RegisterSingleton(service);
            RegisterScoped(service);
        }

        private static void RegisterTransient(IServiceCollection service) { }

        private static void RegisterSingleton(IServiceCollection service) { }

        private static void RegisterScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationServiceUsuario, ApplicationServiceUsuario>();
            service.AddScoped<IApplicationServiceTokenService, ApplicationServiceTokenService>();


            service.AddScoped<IServiceUsuario, ServiceUsuario>();



            service.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
        }

    }
}