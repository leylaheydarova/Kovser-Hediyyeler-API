namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class AppRegistrationServices
    {
        public static IServiceCollection AppServiceRegistrationServices(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("KovserHediyyeler", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            return services;
        }
    }
}
