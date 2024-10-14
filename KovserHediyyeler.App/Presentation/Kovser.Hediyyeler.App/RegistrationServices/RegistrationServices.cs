using MediatR;
using System.Reflection;

namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class RegistrationServices
    {
        public static void RegisterMediaTrServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
