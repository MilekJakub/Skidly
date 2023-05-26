using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Skidly.Infrastructure.EntityFramework.Contexts;

public class WriteDbContextFactory : IDesignTimeDbContextFactory<WriteDbContext>
{
    public WriteDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\Jakub.Milek\Desktop\Skidly\src\Skidly.Api\")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<WriteDbContext>();
        var connectionString = configuration.GetConnectionString("Skidly-Main");
        
        builder.UseSqlServer(connectionString);

        return new WriteDbContext(builder.Options);
    }
}