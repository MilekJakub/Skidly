using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Skidly.Application.Services;
using Skidly.Domain.Aggregates;
using Skidly.Infrastructure.Identity.Repositories;
using Skidly.Infrastructure.Identity.Services;

namespace Skidly.Infrastructure.Identity;

public static class IdentityDependencyInjection
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserRepository, UserRepository>();
        
        var authSettings = new AuthSettings();
        configuration.GetSection("Authorization").Bind(authSettings);

        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Skidly-Main"));
        });
        
        services.AddIdentity<ApplicationUser, Role>()
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Bearer";
            options.DefaultScheme = "Bearer";
            options.DefaultChallengeScheme = "Bearer";
        })
        .AddJwtBearer(config =>
        {
            config.RequireHttpsMetadata = false;
            config.SaveToken = true;
            config.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = authSettings.Issuer,
                ValidAudience = authSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
            };
        });
        
        return services;
    }
}