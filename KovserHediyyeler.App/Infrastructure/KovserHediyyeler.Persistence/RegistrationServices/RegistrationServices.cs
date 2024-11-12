
using KovserHedieyyeler.Application.Abstractions.Services;
using KovserHedieyyeler.Application.Abstractions.Services.Authentications;
using KovserHedieyyeler.Application.Repositories.Abstractions.Addresses;
using KovserHedieyyeler.Application.Repositories.Abstractions.Banks;
using KovserHedieyyeler.Application.Repositories.Abstractions.Baskets;
using KovserHedieyyeler.Application.Repositories.Abstractions.Brands;
using KovserHedieyyeler.Application.Repositories.Abstractions.Departments;
using KovserHedieyyeler.Application.Repositories.Abstractions.Employees;
using KovserHedieyyeler.Application.Repositories.Abstractions.Orders;
using KovserHedieyyeler.Application.Repositories.Abstractions.Positions;
using KovserHedieyyeler.Application.Repositories.Abstractions.Products;
using KovserHedieyyeler.Application.Repositories.Abstractions.Shops;
using KovserHedieyyeler.Application.Repositories.Abstractions.SocialMedias;
using KovserHedieyyeler.Application.Repositories.Abstractions.WishLists;
using KovserHedieyyeler.Application.Repositories.Interfaces;
using KovserHedieyyeler.Application.Repositories.Interfaces.Categories;
using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;

//using KovserHedieyyeler.Application.Repositories.Interfaces.Endpoints;
using KovserHedieyyeler.Application.Repositories.Interfaces.Files;
using KovserHedieyyeler.Application.Repositories.Interfaces.Menus;
using KovserHedieyyeler.Application.Repositories.Interfaces.Orders;
using KovserHedieyyeler.Application.Repositories.Interfaces.Positions;
using KovserHedieyyeler.Application.Repositories.Interfaces.Promotions;
using KovserHediyyeler.Domain.Models.Identity;
using KovserHediyyeler.Persistence.Contexts;
using KovserHediyyeler.Persistence.Repositories.Concretes.Addresses;
using KovserHediyyeler.Persistence.Repositories.Concretes.Banks;
using KovserHediyyeler.Persistence.Repositories.Concretes.Baskets;
using KovserHediyyeler.Persistence.Repositories.Concretes.Brands;
using KovserHediyyeler.Persistence.Repositories.Concretes.Categories;
using KovserHediyyeler.Persistence.Repositories.Concretes.Departments;
using KovserHediyyeler.Persistence.Repositories.Concretes.Employees;
using KovserHediyyeler.Persistence.Repositories.Concretes.Endpoints;

//using KovserHediyyeler.Persistence.Repositories.Concretes.Endpoints;
using KovserHediyyeler.Persistence.Repositories.Concretes.Files;
using KovserHediyyeler.Persistence.Repositories.Concretes.Menus;
using KovserHediyyeler.Persistence.Repositories.Concretes.Orders;
using KovserHediyyeler.Persistence.Repositories.Concretes.Positions;
using KovserHediyyeler.Persistence.Repositories.Concretes.Products;
using KovserHediyyeler.Persistence.Repositories.Concretes.Promotions;
using KovserHediyyeler.Persistence.Repositories.Concretes.Shops;
using KovserHediyyeler.Persistence.Repositories.Concretes.SocialMedias;
using KovserHediyyeler.Persistence.Repositories.Concretes.WishLists;
using KovserHediyyeler.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KovserHediyyeler.Persistence.RegistrationServices
{
    public static class RegistrationServices
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KovserHediyyelerDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddIdentity<WebUser, Role>(options =>
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
                .AddRoleManager<RoleManager<Role>>()
                .AddDefaultTokenProviders();

            //Repositories
            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();

            services.AddScoped<IBankReadRepository, BankReadRepository>();
            services.AddScoped<IBankWriteRepository, BankWriteRepository>();

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IColorReadRepository, ColorReadRepository>();
            services.AddScoped<IColorWriteRepository, ColorWriteRepository>();

            services.AddScoped<ICustomerBankCardReadRepository, CustomerBankCardReadRepository>();
            services.AddScoped<ICustomerBankCardWriteRepository, CustomerBankCardWriteRepository>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            services.AddScoped<IEndpointReadRepository, EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository, EndpointWriteRepository>();

            services.AddScoped<IFileReadRepository, FileReadRepository>();
            services.AddScoped<IFileWriteRepository, FileWriteRepository>();

            services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();

            services.AddScoped<IOrderPaymentReadRepository, OrderPaymentReadRepository>();
            services.AddScoped<IOrderPaymentWriteRepository, OrderPaymentWriteRepository>();

            services.AddScoped<IPositionReadRepository, PositionReadRepository>();
            services.AddScoped<IPositionWriteRepository, PositionWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            services.AddScoped<IProductPropertyReadRepository, ProductPropertyReadRepository>();
            services.AddScoped<IProductPropertyWriteRepository, ProductPropertyWriteRepository>();

            services.AddScoped<IProductCommentReadRepository, ProductCommentReadRepository>();
            services.AddScoped<IProductCommentWriteRepository, ProductCommentWriteRepository>();

            services.AddScoped<IPromotionReadRepository, PromotionReadRepository>();
            services.AddScoped<IPromotionWriteRepository, PromotionWriteRepository>();

            services.AddScoped<IShippingReadRepository, ShippingReadRepository>();
            services.AddScoped<IShippingWriteRepository, ShippingWriteRepository>();

            services.AddScoped<IShopReadRepository, ShopReadRepository>();
            services.AddScoped<IShopWriteRepository, ShopWriteRepository>();

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

            services.AddScoped<IWishListReadRepository, WishListReadRepository>();
            services.AddScoped<IWishListWriteRepository, WishListWriteRepository>();

            services.AddScoped<IWishListItemReadRepository, WishListItemReadRepository>();
            services.AddScoped<IWishListItemWriteRepository, WishListItemWriteRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IBasketService, BasketService>();
            return services;
        }
    }
}
