using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Constants;
using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects.Pomodoro;
using Skidly.Domain.ValueObjects.StudyArea;
using Skidly.Domain.ValueObjects.StudyGoal;

namespace Skidly.Infrastructure.EntityFramework.Configurations;

public class WriteDbContextConfiguration
    : IEntityTypeConfiguration<StudyArea>,
      IEntityTypeConfiguration<StudyGoal>,
      IEntityTypeConfiguration<Pomodoro>
{
    
    public void Configure(EntityTypeBuilder<StudyArea> builder)
    {
        builder
            .Property(u => u.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        var nameConverter =
            new ValueConverter<StudyAreaName, string>(
                areaName => areaName.ToString(),
                areaName => new StudyAreaName(areaName));
        
        var descriptionConverter =
            new ValueConverter<StudyAreaDescription, string>(
                areaDescription => areaDescription.ToString(),
                areaDescription => new StudyAreaDescription(areaDescription));

        builder
            .Property(typeof(StudyAreaName), "_name")
            .HasConversion(nameConverter)
            .HasColumnName("Name");
        
        builder
            .Property(typeof(StudyAreaDescription), "_description")
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");

        builder
            .HasOne(typeof(ApplicationUser), "_user")
            .WithMany("_areas");

        builder
            .ToTable("StudyAreas");
    }

    public void Configure(EntityTypeBuilder<StudyGoal> builder)
    {
        builder
            .Property(sg => sg.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        var nameConverter =
            new ValueConverter<StudyGoalName, string>(
                goalName => goalName.ToString(),
                goalName => new StudyGoalName(goalName));
        
        var descriptionConverter =
            new ValueConverter<StudyGoalDescription, string>(
                description => description.ToString(),
                description => new StudyGoalDescription(description));
        
        var categoryConverter =
            new ValueConverter<StudyGoalCategory, string>(
                category => category.ToString(),
                category => (StudyGoalCategory) Enum.Parse(typeof(StudyGoalCategory), category));
                
        var expectedLearningTimeConverter =
            new ValueConverter<TimeSpan?, string?>(
                expectedLearningTime => expectedLearningTime != null ? expectedLearningTime.ToString() : null,
                expectedLearningTime => expectedLearningTime != null ? TimeSpan.Parse(expectedLearningTime) : null);

            var deadlineConverter =
            new ValueConverter<Deadline?, DateTime?>(
                deadline => deadline != null ? deadline.Value : null,
                deadline => deadline != null ? new Deadline(deadline.Value) : null);
        
        builder
            .Property(typeof(StudyGoalName), "_name")
            .HasConversion(nameConverter)
            .HasColumnName("Name");
        
        builder
            .Property(typeof(StudyGoalDescription), "_description")
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");
        
        builder
            .Property(typeof(StudyGoalCategory), "_category")
            .HasConversion(categoryConverter)
            .HasColumnName("Category");

        builder
            .Property(typeof(TimeSpan?), "_expectedLearningTime")
            .HasConversion(expectedLearningTimeConverter)
            .HasColumnName("ExpectedLearningTime");
        
        builder
            .Property(typeof(Deadline), "_deadline")
            .HasConversion(deadlineConverter)
            .HasColumnName("Deadline");

        builder
            .HasOne(typeof(StudyArea), "_area")
            .WithMany("_goals");

        builder
            .ToTable("StudyGoals");
    }

    public void Configure(EntityTypeBuilder<Pomodoro> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        var topicConverter =
            new ValueConverter<PomodoroTopic, string>(
                topic => topic.ToString(),
                topic => new PomodoroTopic(topic));
        
        var expectedDurationConverter =
            new ValueConverter<TimeSpan, string>(
                expectedDuration => expectedDuration.ToString(),
                expectedDuration => TimeSpan.Parse(expectedDuration));
        
        var durationConverter =
            new ValueConverter<TimeSpan, string>(
                duration => duration.ToString(),
                duration => TimeSpan.Parse(duration));

        builder
            .Property(typeof(PomodoroTopic), "_topic")
            .HasConversion(topicConverter)
            .HasColumnName("Topic");
        
        builder
            .Property(typeof(TimeSpan), "_expectedDuration")
            .HasConversion(expectedDurationConverter)
            .HasColumnName("ExpectedDuration");

        builder
            .Property(typeof(TimeSpan), "_duration")
            .HasConversion(durationConverter)
            .HasColumnName("Duration");

        builder
            .HasOne(typeof(StudyGoal), "_goal")
            .WithMany("_pomodoros");

        builder
            .ToTable("Pomodoros");
    }
}