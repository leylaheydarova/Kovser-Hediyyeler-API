using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection;

namespace Kovser.Hediyyeler.App.RegistrationServices
{
    public static class RegistrationServices
    {
        public static void RegisterMediaTrServices(this IServiceCollection services)
        {
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly([typeof(Program).Assembly, typeof(RegisteredServices).Assembly]);
            });
           
        }
    }
}

