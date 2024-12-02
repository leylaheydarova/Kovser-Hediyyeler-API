using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class AppRegistrationServices
    {
        public static IServiceCollection AppServiceRegistrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("KovserHediyyeler", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidAudience = configuration["Token:Audience"],
                        ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
                            expires != null ? expires > DateTime.UtcNow : false,

                        NameClaimType = ClaimTypes.Name
                    };
                });
            return services;
        }

        //public static void ConfigureLogging(this IConfiguration configuration)
        //{
        //    Logger log = new LoggerConfiguration()
        //        .WriteTo.Console()
        //        .WriteTo.File("logs/log.txt")
        //        .WriteTo.MSSqlServer(
        //            connectionString: "Server=.;Database=KovserHediyyelerDb;Integrated Security=true;TrustServerCertificate=true;",
        //            sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true }//,
        //            //columnOptions: new Dictionary<string, ColumnBuilder>
        //            )
        //        .CreateLogger();
        //}



    }
}

