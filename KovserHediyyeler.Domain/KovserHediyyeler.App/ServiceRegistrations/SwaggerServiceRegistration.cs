using Microsoft.OpenApi.Models;

namespace KovserHediyyeler.App.ServiceRegistrations
{
    public static class SwaggerServiceRegistration
    {
        public static IServiceCollection RegisterSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("admin_v1", new OpenApiInfo { Title = "My API - admin_v1", Version = "admin_v1" });
        c.SwaggerDoc("client_v1", new OpenApiInfo { Title = "My API - client_v1", Version = "client_v1" });

        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
    }
    );

            return services;
        }

    }
}
