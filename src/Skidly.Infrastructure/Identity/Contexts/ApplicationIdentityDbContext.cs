using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Infrastructure.Identity.Configurations;

namespace Skidly.Infrastructure.Identity;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        var configuration = new IdentityDbContextConfiguration();
        
        builder.ApplyConfiguration<ApplicationUser>(configuration);
        builder.ApplyConfiguration<Role>(configuration);
        builder.ApplyConfiguration<IdentityUserRole<string>>(configuration);
    }
}
