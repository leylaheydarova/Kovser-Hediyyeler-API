using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Abstractions.Services.Configurations;
using KovserHedieyyeler.Application.Abstractions.StorageServices;
using KovserHedieyyeler.Application.Abstractions.Tokens;
using KovserHedieyyeler.Infrastructure.Services.StorageServices;
using KovserHedieyyeler.Infrastructure.Services.StorageServices.LocalStorage;
using KovserHediyyeler.Domain.Enums;
using KovserHediyyeler.Infrastructure.Services;
using KovserHediyyeler.Infrastructure.Services.Configurations;
using KovserHediyyeler.Infrastructure.Services.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace KovserHediyyeler.Infrastructure.RegistrationServices
{
    public static class RegistrationServices
    {
        public static IServiceCollection RegisterStorageServices (this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            return services;
        }

        public static IServiceCollection AddStorage<T> (this IServiceCollection services) where T: class, IStorage
        {
            services.AddScoped<IStorage, T>();
            return services;
        }

        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorageService>();
                    break;
                default:
                    serviceCollection.AddScoped<IStorage, LocalStorageService>();
                    break;
            }
        }

        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IMailService, MailService>();
            return services;
        }
    }
}
