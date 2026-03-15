using Microsoft.Extensions.DependencyInjection;
using RunMate.Application.Auth.Commands;

namespace RunMate.Application.DependencyInjection;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RegisterUserCommandHandler>();
        services.AddScoped<LoginUserCommandHandler>();

        return services;
    }
}
