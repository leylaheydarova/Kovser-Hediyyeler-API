using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class LoginRegistrationServices
    {
        public static IServiceCollection RegisterLoginServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(

                x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

                }
                ).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
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
            //    });
            return services;
        }

    }
}
