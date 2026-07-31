using FinTracker.Application.Interfaces.Services;
using FinTracker.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            return services;
        }
    }
}
