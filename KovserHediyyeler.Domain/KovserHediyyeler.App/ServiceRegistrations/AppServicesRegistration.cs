namespace KovserHediyyeler.App.ServiceRegistrations
{
    public static class AppServicesRegistration
    {
        public static IServiceCollection AppServiceRegistrationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy("KovserHediyyeler", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer("Admin", options =>
            //    {
            //        options.TokenValidationParameters = new()
            //        {
            //            ValidateAudience = true,
            //            ValidateIssuer = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,

            //            ValidAudience = configuration["Token:Audience"],
            //            ValidIssuer = configuration["Token:Issuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
            //            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) =>
            //                expires != null ? expires > DateTime.UtcNow : false,

            //            NameClaimType = ClaimTypes.Name
            //        };
            //    });
            return services;
        }
    }
}
