using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitectureTemplate.Application
{
    public static class ApplicationDependency
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register all command and query handlers using MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
