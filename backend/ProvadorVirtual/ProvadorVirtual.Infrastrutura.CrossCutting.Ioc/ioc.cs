using Microsoft.Extensions.DependencyInjection;

namespace ProvadorVirtual.Infrastrutura.Crosscutting.Ioc
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
            
        }

    }
}