using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Skidly.Infrastructure.EntityFramework.Contexts;

public class ReadDbContextFactory : IDesignTimeDbContextFactory<ReadDbContext>
{
    public ReadDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(@"C:\Users\Jakub.Milek\Desktop\Skidly\src\Skidly.Api\")
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ReadDbContext>();
        var connectionString = configuration.GetConnectionString("Skidly-Main");
        
        builder.UseSqlServer(connectionString);

        return new ReadDbContext(builder.Options);
    }
}