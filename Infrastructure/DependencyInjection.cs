using Application.Users.Common.Interfaces;
using Infrastructure.Common.Persistence;
using Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<UserManagementDbContext>(options =>
            options.UseNpgsql(connectionString));
        
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => 
            serviceProvider.GetRequiredService<UserManagementDbContext>());
        
        return services;
    }
}