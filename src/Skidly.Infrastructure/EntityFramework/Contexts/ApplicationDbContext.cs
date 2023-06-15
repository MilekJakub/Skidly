using Microsoft.EntityFrameworkCore;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;
using Skidly.Infrastructure.EntityFramework.Configurations;

namespace Skidly.Infrastructure.EntityFramework.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<StudyArea> StudyAreas { get; set; }
    public DbSet<StudyGoal> StudyGoals { get; set; }
    public DbSet<Pomodoro> Pomodoros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ApplicationDbContextConfiguration();

        modelBuilder.ApplyConfiguration<ApplicationUser>(configuration);
        modelBuilder.ApplyConfiguration<StudyArea>(configuration);
        modelBuilder.ApplyConfiguration<StudyGoal>(configuration);
        modelBuilder.ApplyConfiguration<Pomodoro>(configuration);
    }
}