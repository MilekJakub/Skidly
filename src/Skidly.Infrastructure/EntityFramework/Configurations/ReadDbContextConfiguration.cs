using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skidly.Infrastructure.EntityFramework.Models;

namespace Skidly.Infrastructure.EntityFramework.Configurations;

public class ReadDbContextConfiguration
    : IEntityTypeConfiguration<UserReadModel>, 
      IEntityTypeConfiguration<StudyAreaReadModel>,
      IEntityTypeConfiguration<StudyGoalReadModel>,
      IEntityTypeConfiguration<PomodoroReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .HasMany(u => u.Areas)
            .WithOne(sa => sa.User);
    }

    public void Configure(EntityTypeBuilder<StudyAreaReadModel> builder)
    {
        builder.ToTable("StudyAreas");

        builder.HasKey(sa => sa.Id);

        builder
            .HasMany(sa => sa.Goals)
            .WithOne(sg => sg.StudyArea);
    }

    public void Configure(EntityTypeBuilder<StudyGoalReadModel> builder)
    {
        builder.ToTable("StudyGoals");

        builder.HasKey(sg => sg.Id);

        builder
            .HasMany(sg => sg.Pomodoros)
            .WithOne(p => p.StudyGoal);
    }

    public void Configure(EntityTypeBuilder<PomodoroReadModel> builder)
    {
        builder.ToTable("Pomodoros");

        builder.HasKey(p => p.Id);
    }
}