using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Talavera.Hipermaxi.Application.Abstractions.Data;
using Talavera.Hipermaxi.Domain.Abstractions;
using Talavera.Hipermaxi.Domain.Users;
using Talavera.Hipermaxi.Infrastructure.Repositories;

namespace Talavera.Hipermaxi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            /*options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();*/
        });

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}