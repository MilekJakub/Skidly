using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Skidly.Infrastructure.Identity.Contexts;

public class ApplicationIdentityDbContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext>
{
    public ApplicationIdentityDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\Jakub.Milek\Desktop\Skidly\src\Skidly.Api\")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
        var connectionString = configuration.GetConnectionString("Skidly-Main");
        
        builder.UseSqlServer(connectionString);

        return new ApplicationIdentityDbContext(builder.Options);
    }
}