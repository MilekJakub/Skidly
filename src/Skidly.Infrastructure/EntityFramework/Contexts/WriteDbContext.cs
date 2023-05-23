using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Entities;

namespace Skidly.Infrastructure.EntityFramework.Contexts;

public class WriteDbContext : DbContext
{
    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
        
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<StudyArea> StudyAreas { get; set; }
    public DbSet<StudyGoal> StudyGoals { get; set; }
    public DbSet<Pomodoro> Pomodoros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}