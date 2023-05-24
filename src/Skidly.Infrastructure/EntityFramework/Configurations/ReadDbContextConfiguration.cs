using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skidly.Infrastructure.EntityFramework.Models;

namespace Skidly.Infrastructure.EntityFramework.Configurations;

public class ReadDbContextConfiguration
    : IEntityTypeConfiguration<ApplicationUserReadModel>, 
      IEntityTypeConfiguration<RoleReadModel>,
      IEntityTypeConfiguration<StudyAreaReadModel>,
      IEntityTypeConfiguration<StudyGoalReadModel>,
      IEntityTypeConfiguration<PomodoroReadModel>
{
    public void Configure(EntityTypeBuilder<ApplicationUserReadModel> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users);
    }
    
    public void Configure(EntityTypeBuilder<RoleReadModel> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);
    }

    public void Configure(EntityTypeBuilder<StudyAreaReadModel> builder)
    {
        builder.ToTable("StudyAreas");

        builder.HasKey(sa => sa.Id);

        builder
            .HasOne(sa => sa.ApplicationUser)
            .WithMany(u => u.StudyAreas);
    }

    public void Configure(EntityTypeBuilder<StudyGoalReadModel> builder)
    {
        builder.ToTable("StudyGoals");

        builder.HasKey(sg => sg.Id);

        builder
            .HasOne(sg => sg.StudyArea)
            .WithMany(sa => sa.StudyGoals);
    }

    public void Configure(EntityTypeBuilder<PomodoroReadModel> builder)
    {
        builder.ToTable("Pomodoros");
        
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.StudyGoal)
            .WithMany(sg => sg.Pomodoros);
    }
}