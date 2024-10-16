using Microsoft.EntityFrameworkCore.Internal;

namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class RegistrationServices
    {
        public static void RegisterMediaTrServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisteredServices>());

        }
    }
}

