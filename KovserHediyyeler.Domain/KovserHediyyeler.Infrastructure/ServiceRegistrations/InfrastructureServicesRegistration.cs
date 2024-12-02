using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KovserHediyyeler.Infrastructure.ServiceRegistrations
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            return services;
        }
    }
}
