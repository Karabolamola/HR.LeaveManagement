using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            var localAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(localAssembly);
            services.AddMediatR(localAssembly);
            return services;
        }
    }
}