//using KovserHediyyeler.Domain.Models.Identity;
//using KovserHediyyeler.Persistence.Contexts;
//using Microsoft.AspNetCore.Identity;


//namespace KovserHedieyyeler.Application.ServiceRegistrations
//{
//    public static class RegisterRegistrationServices
//    {
//        public static IServiceCollection RegisterUserServices(this IServiceCollection services)
//        {
//            services.AddIdentity<WebUser, UserRole>(options =>
//            {

//                // Default Password settings.
//                options.Password.RequireDigit = true;
//                options.Password.RequireLowercase = true;
//                options.Password.RequireNonAlphanumeric = false;
//                options.Password.RequireUppercase = true;
//                options.Password.RequiredLength = 6;
//                options.Password.RequiredUniqueChars = 1;

//                // Default Lockout settings.
//                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//                options.Lockout.MaxFailedAccessAttempts = 5;
//                options.Lockout.AllowedForNewUsers = true;

//                // Default SignIn settings.
//                options.SignIn.RequireConfirmedEmail = false;
//                options.SignIn.RequireConfirmedPhoneNumber = false;

//                // Default User settings.
//                options.User.AllowedUserNameCharacters =
//                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//                options.User.RequireUniqueEmail = false;
//            })
//            .AddDefaultTokenProviders().AddEntityFrameworkStores<KovserHediyyelerDbContext>();

            
//            return services;

//        }
//    }
//}
