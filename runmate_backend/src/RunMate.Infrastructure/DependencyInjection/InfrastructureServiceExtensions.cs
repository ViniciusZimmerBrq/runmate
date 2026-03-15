using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RunMate.Application.Auth.Interfaces;
using RunMate.Domain.Repositories;
using RunMate.Infrastructure.Persistence;
using RunMate.Infrastructure.Security;

namespace RunMate.Infrastructure.DependencyInjection;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddSingleton<IUserRepository, InMemoryUserRepository>();
        services.AddSingleton<IPasswordHashService, PasswordHashService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
