using FluentValidation;
using FluentValidation.AspNetCore;
using KovserHediyyeler.Application.Validations.Brands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KovserHedieyyeler.Application.ServiceRegistrations
{
    public static class RegistrationServices
    {
        public static void RegisterLibrariesServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(RegistrationServices));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssemblyContaining<BrandCommandDtoValidation>().AddFluentValidationClientsideAdapters();
        }
    }
}
