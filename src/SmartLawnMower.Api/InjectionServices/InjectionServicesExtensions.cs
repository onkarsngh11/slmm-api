using SmartLawnMower.Infrastructure.Contracts;
using SmartLawnMower.Infrastructure.Models;
using SmartLawnMower.Services;

namespace SmartLawnMower.Api.InjectionServices
{
    public static class InjectionServicesExtensions
    {
        public static IServiceCollection AddInjectionServices(this IServiceCollection services)
        {
            services.AddSingleton<ILawnMowerService, LawnMowerService>();
            services.AddSingleton<LawnMower>();
            return services;
        }
    }
}
