using Microsoft.EntityFrameworkCore;
using Skidly.Infrastructure.EntityFramework.Configurations;
using Skidly.Infrastructure.EntityFramework.Models;

namespace Skidly.Infrastructure.EntityFramework.Contexts;

public class ReadDbContext : DbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUserReadModel> Users { get; set; }
    public DbSet<StudyAreaReadModel> StudyAreas { get; set; }
    public DbSet<StudyGoalReadModel> StudyGoals { get; set; }
    public DbSet<PomodoroReadModel> Pomodoros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var configuration = new ReadDbContextConfiguration();

        modelBuilder.ApplyConfiguration<StudyAreaReadModel>(configuration);
        modelBuilder.ApplyConfiguration<StudyGoalReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PomodoroReadModel>(configuration);
    }
}