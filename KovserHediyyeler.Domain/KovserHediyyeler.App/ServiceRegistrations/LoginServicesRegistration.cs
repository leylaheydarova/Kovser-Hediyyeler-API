using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KovserHediyyeler.App.ServiceRegistrations
{
    public static class LoginServicesRegistration
    {
        public static IServiceCollection RegisterLoginServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token is valid.");
                        return Task.CompletedTask;
                    }
                };
            });

            //    services.AddSwaggerGen(c =>
            //    {
            //        // JWT Bearer Authentication üçün Swagger konfiqurasiyası
            //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //        {
            //            In = ParameterLocation.Header,
            //            Description = "Please enter JWT with Bearer into field",
            //            Name = "Authorization",
            //            Type = SecuritySchemeType.ApiKey
            //        });

            //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            }
            //        },
            //        new string[] {}
            //    }
            //});
            //    }); jwt iki defe konfiqurasiya olunur. ona gore xeta verirdi, men de bagladim.
            return services;
        }
    }
}
