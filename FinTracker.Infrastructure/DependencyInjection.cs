using FinTracker.Application.Interfaces.Services;
using FinTracker.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FinTracker.Infrastructure.Persistence;
using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Infrastructure.Repositories;
using FinTracker.Application.UseCases.Users;

namespace FinTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FinTrackerDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
