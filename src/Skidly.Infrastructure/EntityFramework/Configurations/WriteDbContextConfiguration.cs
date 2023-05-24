using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Constants;
using Skidly.Domain.Entities;
using Skidly.Domain.ValueObjects;
using Skidly.Domain.ValueObjects.ApplicationUser;
using Skidly.Domain.ValueObjects.Pomodoro;
using Skidly.Domain.ValueObjects.Role;
using Skidly.Domain.ValueObjects.StudyArea;
using Skidly.Domain.ValueObjects.StudyGoal;

namespace Skidly.Infrastructure.EntityFramework.Configurations;

public class WriteDbContextConfiguration
    : IEntityTypeConfiguration<ApplicationUser>,
      IEntityTypeConfiguration<Role>,
      IEntityTypeConfiguration<StudyArea>,
      IEntityTypeConfiguration<StudyGoal>,
      IEntityTypeConfiguration<Pomodoro>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(u => u.Id);

        var usernameConverter =
            new ValueConverter<Username, string>(
                username => username.ToString(),
                username => new Username(username));
        
        var passwordConverter = 
            new ValueConverter<PasswordHash, string>(
                hash => hash.ToString(),
                hash => new PasswordHash(hash));
        
        var emailConverter =
            new ValueConverter<EmailAddress, string>(
                email => email.ToString(),
                email => new EmailAddress(email));
        
        var fullnameConverter =
            new ValueConverter<Fullname?, string?>(
                fullname => fullname != null ? fullname.ToString() : null,
                fullname => fullname != null ? new Fullname(fullname) : null);
        
        var dateOfBirthConverter =
            new ValueConverter<DateOfBirth?, DateTime?>(
                dateOfBirth => dateOfBirth != null ? dateOfBirth.Value : null,
                dateOfBirth => dateOfBirth != null ? new DateOfBirth(dateOfBirth.ToString()!) : null);

        var countryConverter =
            new ValueConverter<Country?, string?>(
                country => country != null ? country.Code : null,
                country => country != null ? new Country(country) : null);

        builder
            .Property(u => u.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));

        builder
            .Property(u => u.Username)
            .HasConversion(usernameConverter)
            .HasColumnName("Username");

        builder
            .Property(u => u.PasswordHash)
            .HasConversion(passwordConverter)
            .HasColumnName("PasswordHash");
        
        builder
            .Property(u => u.Email)
            .HasConversion(emailConverter)
            .HasColumnName("Email");

        builder
            .Property(u => u.Fullname)
            .HasConversion(fullnameConverter)
            .HasColumnName("Fullname");

        builder
            .Property(u => u.DateOfBirth)
            .HasConversion(dateOfBirthConverter)
            .HasColumnName("DateOfBirth");

        builder
            .Property(u => u.Country)
            .HasConversion(countryConverter)
            .HasColumnName("Country");

        builder
            .HasOne(u => u.Role)
            .WithMany(r => r.Users);
    }

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(u => u.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        var nameConverter =
            new ValueConverter<RoleName, string>(
                name => name.ToString(),
                name => new RoleName(name));

        builder
            .Property(r => r.Name)
            .HasConversion(nameConverter)
            .HasColumnName("Name");
    }
    
    public void Configure(EntityTypeBuilder<StudyArea> builder)
    {
        var nameConverter =
            new ValueConverter<AreaName, string>(
                areaName => areaName.ToString(),
                areaName => new AreaName(areaName));
        
        var descriptionConverter =
            new ValueConverter<AreaDescription, string>(
                areaDescription => areaDescription.ToString(),
                areaDescription => new AreaDescription(areaDescription));
        
        var timeSpentStudyingConverter =
            new ValueConverter<TimeSpan, string>(
                timeSpentStudying => timeSpentStudying.ToString(),
                timeSpentStudying => TimeSpan.Parse(timeSpentStudying));
        
        builder
            .Property(u => u.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        builder
            .Property(sa => sa.Name)
            .HasConversion(nameConverter)
            .HasColumnName("Name");
        
        builder
            .Property(sa => sa.Description)
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");
        
        builder
            .Property(sa => sa.TimeSpentStudying)
            .HasConversion(timeSpentStudyingConverter)
            .HasColumnName("TimeSpentStudying");

        builder
            .HasOne(sa => sa.User)
            .WithMany(u => u.StudyAreas);
    }

    public void Configure(EntityTypeBuilder<StudyGoal> builder)
    {
        var nameConverter =
            new ValueConverter<GoalName, string>(
                goalName => goalName.ToString(),
                goalName => new GoalName(goalName));
        
        var descriptionConverter =
            new ValueConverter<GoalDescription, string>(
                description => description.ToString(),
                description => new GoalDescription(description));
        
        var categoryConverter =
            new ValueConverter<GoalCategory, string>(
                category => category.ToString(),
                category => (GoalCategory) Enum.Parse(typeof(GoalCategory), category));
                
        var expectedLearningTimeConverter =
            new ValueConverter<TimeSpan?, string?>(
                expectedLearningTime => expectedLearningTime != null ? expectedLearningTime.ToString() : null,
                expectedLearningTime => expectedLearningTime != null ? TimeSpan.Parse(expectedLearningTime) : null);

            var deadlineConverter =
            new ValueConverter<Deadline?, DateTime?>(
                deadline => deadline != null ? deadline.Value : null,
                deadline => deadline != null ? new Deadline(deadline.Value) : null);
        
        var timeSpentStudyingConverter =
            new ValueConverter<TimeSpan, string>(
                timeSpentStudying => timeSpentStudying.ToString(),
                timeSpentStudying => TimeSpan.Parse(timeSpentStudying));
        
        builder
            .Property(sg => sg.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));
        
        builder
            .Property(sg => sg.Name)
            .HasConversion(nameConverter)
            .HasColumnName("Name");
        
        builder
            .Property(sg => sg.Description)
            .HasConversion(descriptionConverter)
            .HasColumnName("Description");
        
        builder
            .Property(sg => sg.Category)
            .HasConversion(categoryConverter)
            .HasColumnName("Category");

        builder
            .Property(sg => sg.ExpectedLearningTime)
            .HasConversion(expectedLearningTimeConverter)
            .HasColumnName("ExpectedLearningTime");
        
        builder
            .Property(sg => sg.Deadline)
            .HasConversion(deadlineConverter)
            .HasColumnName("Deadline");
        
        builder
            .Property(sg => sg.TimeSpentStudying)
            .HasConversion(timeSpentStudyingConverter)
            .HasColumnName("TimeSpentStudying");

        builder
            .HasOne(sg => sg.Area)
            .WithMany(sa => sa.Goals);
    }

    public void Configure(EntityTypeBuilder<Pomodoro> builder)
    {
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
            .Property(p => p.Id)
            .HasConversion(id => id.ToString(), id => Guid.Parse(id));

        builder
            .Property(p => p.Topic)
            .HasConversion(topicConverter)
            .HasColumnName("Topic");
        
        builder
            .Property(p => p.ExpectedDuration)
            .HasConversion(expectedDurationConverter)
            .HasColumnName("ExpectedDuration");

        builder
            .Property(p => p.Duration)
            .HasConversion(durationConverter)
            .HasColumnName("Duration");
    }
}