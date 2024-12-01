using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Application.Repositories.Files;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using KovserHediyyeler.Persistence.Repositories.Addresses;
using KovserHediyyeler.Persistence.Repositories.Brands;
using KovserHediyyeler.Persistence.Repositories.Categories;
using KovserHediyyeler.Persistence.Repositories.Departments;
using KovserHediyyeler.Persistence.Repositories.Employees;
using KovserHediyyeler.Persistence.Repositories.Files;
using KovserHediyyeler.Persistence.Repositories.Positions;
using KovserHediyyeler.Persistence.Repositories.Products;
using KovserHediyyeler.Persistence.Repositories.Promotions;
using KovserHediyyeler.Persistence.Repositories.Shops;
using KovserHediyyeler.Persistence.Repositories.SocialMedias;
using KovserHediyyeler.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IColorReadRepository = KovserHediyyeler.Application.Repositories.Products.IColorReadRepository;
using IColorWriteRepository = KovserHediyyeler.Application.Repositories.Products.IColorWriteRepository;

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

            services.AddIdentity<WebUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
                .AddEntityFrameworkStores<KovserHediyyelerDbContext>()
                .AddDefaultTokenProviders();



            //Repositories
            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IProductPropertyReadRepository, ProductPropertyReadRepository>();
            services.AddScoped<IProductPropertyWriteRepository, ProductPropertyWriteRepository>();

            services.AddScoped<IProductShopWriteRepository, ProductShopWriteRepository>();

            services.AddScoped<IPositionReadRepository, PositionReadRepository>();
            services.AddScoped<IPositionWriteRepository, PositionWriteRepository>();

            services.AddScoped<IPromotionReadRepository, PromotionReadRepository>();
            services.AddScoped<IPromotionWriteRepository, PromotionWriteRepository>();

            services.AddScoped<IShopReadRepository, ShopReadRepository>();
            services.AddScoped<IShopWriteRepository, ShopWriteRepository>();

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

            //Services
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
