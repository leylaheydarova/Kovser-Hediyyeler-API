using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHedieyyeler.Application.Repositories.Interfaces.Categories;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Persistence.Contexts;
using KovserHediyyeler.Persistence.Repositories.Brands;
using KovserHediyyeler.Persistence.Repositories.Concretes.Categories;
using KovserHediyyeler.Persistence.Repositories.Concretes.Departments;
using KovserHediyyeler.Persistence.Repositories.Concretes.SocialMedias;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KovserHediyyeler.Persistence.ServiceRegistrations
{
    public static class PersistenceServicesRegistrations
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KovserHediyyelerDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();
            return services;
        }
    }
}
