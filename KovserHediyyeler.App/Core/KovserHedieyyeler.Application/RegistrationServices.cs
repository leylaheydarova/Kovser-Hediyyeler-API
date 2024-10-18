using FluentValidation;
using FluentValidation.AspNetCore;
using KovserHedieyyeler.Application.Profiles;
using KovserHedieyyeler.Application.Validation.Categories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KovserHedieyyeler.Application
{
    public static class RegistrationServices
    {
        public static void RegisterLibrariesServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(RegistrationServices));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssemblyContaining<CategoryCommandDtoValidation>().AddFluentValidationClientsideAdapters();
            services.AddAutoMapper(typeof(CategoryMapper));
        }
    }
}
