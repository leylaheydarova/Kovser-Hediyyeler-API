using KovserHediyyeler.Application.Abstractions;
using KovserHediyyeler.Application.Abstractions.Authentication;
using KovserHediyyeler.Application.Abstractions.Products;
using KovserHediyyeler.Application.Repositories.Addresses;
using KovserHediyyeler.Application.Repositories.Baskets;
using KovserHediyyeler.Application.Repositories.Brands;
using KovserHediyyeler.Application.Repositories.Categories;
using KovserHediyyeler.Application.Repositories.Departments;
using KovserHediyyeler.Application.Repositories.Employees;
using KovserHediyyeler.Application.Repositories.Orders;
using KovserHediyyeler.Application.Repositories.Positions;
using KovserHediyyeler.Application.Repositories.Products;
using KovserHediyyeler.Application.Repositories.Promotions;
using KovserHediyyeler.Application.Repositories.Shops;
using KovserHediyyeler.Application.Repositories.SocialMedias;
using KovserHediyyeler.Application.Repositories.WishLists;
using KovserHediyyeler.Domain.Models;
using KovserHediyyeler.Persistence.Contexts;
using KovserHediyyeler.Persistence.Repositories.Addresses;
using KovserHediyyeler.Persistence.Repositories.Baskets;
using KovserHediyyeler.Persistence.Repositories.Brands;
using KovserHediyyeler.Persistence.Repositories.Categories;
using KovserHediyyeler.Persistence.Repositories.Departments;
using KovserHediyyeler.Persistence.Repositories.Employees;
using KovserHediyyeler.Persistence.Repositories.Orders;
using KovserHediyyeler.Persistence.Repositories.Positions;
using KovserHediyyeler.Persistence.Repositories.Products;
using KovserHediyyeler.Persistence.Repositories.Promotions;
using KovserHediyyeler.Persistence.Repositories.Shops;
using KovserHediyyeler.Persistence.Repositories.SocialMedias;
using KovserHediyyeler.Persistence.Repositories.WishLists;
using KovserHediyyeler.Persistence.Services;
using KovserHediyyeler.Persistence.Services.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KovserHediyyeler.Persistence.ServiceRegistrations
{
    public static class PersistenceServicesRegistrations
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KovserHediyyelerDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")), ServiceLifetime.Scoped);

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

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

            services.AddScoped<IBrandReadRepository, BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
            services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

            services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            //services.AddScoped<IInvoceFileReadRepository, InvoiceFileReadRepository>();
            //services.AddScoped<IInvoceFileWriteRepository, InvoiceFileWriteRepository>();

            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderDetailReadRepository, OrderDetailReadRepository>();
            services.AddScoped<IOrderDetailWriteRepository, OrderDetailWriteRepository>();
            services.AddScoped<IOrderPaymentReadRepository, OrderPaymentReadRepository>();
            services.AddScoped<IOrderPaymentWriteRepository, OrderPaymentWriteRepository>();

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            services.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            services.AddScoped<IProductPropertyReadRepository, ProductPropertyReadRepository>();
            services.AddScoped<IProductPropertyWriteRepository, ProductPropertyWriteRepository>();
            services.AddScoped<IProductShopWriteRepository, ProductShopWriteRepository>();
            services.AddScoped<IProductColorReadRepository, ProductColorReadRepository>();
            services.AddScoped<IProductColorWriteRepository, ProductColorWriteRepository>();
            services.AddScoped<IProductSizeReadRepository, ProductSizeReadRepository>();
            services.AddScoped<IProductSizeWriteRepository, ProductSizeWriteRepository>();

            services.AddScoped<IPositionReadRepository, PositionReadRepository>();
            services.AddScoped<IPositionWriteRepository, PositionWriteRepository>();

            services.AddScoped<IPromotionReadRepository, PromotionReadRepository>();
            services.AddScoped<IPromotionWriteRepository, PromotionWriteRepository>();

            services.AddScoped<IShippingReadRepository, ShippingReadRepository>();
            services.AddScoped<IShippingWriteRepository, ShippingWriteRepository>();

            services.AddScoped<IShopReadRepository, ShopReadRepository>();
            services.AddScoped<IShopWriteRepository, ShopWriteRepository>();

            services.AddScoped<ISocialMediaReadRepository, SocialMediaReadRepository>();
            services.AddScoped<ISocialMediaWriteRepository, SocialMediaWriteRepository>();

            services.AddScoped<IWishListItemReadRepository, WishListItemReadRepository>();
            services.AddScoped<IWishListItemWriteRepository, WishListItemWriteRepository>();
            services.AddScoped<IWishListReadRepository, WishListReadRepository>();
            services.AddScoped<IWishListWriteRepository, WishListWriteRepository>();

            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IInvoiceFileService, InvoiceFileService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IProductPostService, ProductPostService>();
            services.AddScoped<IProductDeleteService, ProductDeleteService>();
            services.AddScoped<IProductPatchService, ProductPatchService>();
            services.AddScoped<IProductGetAllService, ProductGetAllService>();
            services.AddScoped<IProductGetSingleService, ProductGetSingleService>();
            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWishListService, WishListService>();
            services.AddHttpClient();
            return services;
        }
    }
}
