using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework;
using Skidly.Infrastructure.EntityFramework.Contexts;
using Skidly.Infrastructure.EntityFramework.Repositories;
using Skidly.Infrastructure.Identity;
using Skidly.Shared.Abstractions;

namespace Skidly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityServices(configuration);
        services.AddEntityFrameworkServices(configuration);
        
        return services;
    }
}