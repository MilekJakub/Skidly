using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skidly.Infrastructure.EntityFramework.Models;

namespace Skidly.Infrastructure.EntityFramework.Configurations;

public class ReadDbContextConfiguration
    : IEntityTypeConfiguration<StudyAreaReadModel>,
      IEntityTypeConfiguration<StudyGoalReadModel>,
      IEntityTypeConfiguration<PomodoroReadModel>
{

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