using FinTracker.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace FinTracker.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<RegisterUserUseCase>();
            return services;
        }
    }
}
