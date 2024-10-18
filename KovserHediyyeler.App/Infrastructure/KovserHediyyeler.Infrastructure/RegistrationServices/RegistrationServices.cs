using KovserHedieyyeler.Application.Abstractions.StorageServices;
using KovserHedieyyeler.Infrastructure.Services.StorageServices;
using KovserHedieyyeler.Infrastructure.Services.StorageServices.LocalStorage;
using KovserHediyyeler.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
