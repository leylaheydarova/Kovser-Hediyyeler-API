using FluentValidation;
using FluentValidation.AspNetCore;
using KovserHediyyeler.Application.Constants;
using KovserHediyyeler.Application.Validations.Brands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KovserHedieyyeler.Application.ServiceRegistrations
{
    public static class RegistrationServices
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(RegistrationServices));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssemblyContaining<BrandCommandDtoValidation>().AddFluentValidationClientsideAdapters();
            services.AddSingleton<FileConstants>();
            services.AddHttpContextAccessor();
        }
    }
}
