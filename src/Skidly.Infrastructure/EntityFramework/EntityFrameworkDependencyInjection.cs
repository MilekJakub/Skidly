using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skidly.Domain.Repositories;
using Skidly.Infrastructure.EntityFramework.Contexts;
using Skidly.Infrastructure.EntityFramework.Repositories;
using Skidly.Shared.Abstractions;

namespace Skidly.Infrastructure.EntityFramework;

public static class EntityFrameworkDependencyInjection
{

    public static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudyAreaRepository, StudyAreaRepository>();
        services.AddScoped<IStudyGoalRepository, StudyGoalRepository>();
        
        services.AddDbContext<ApplicationDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("Skidly-Main"));
        });

        return services;
    }
}