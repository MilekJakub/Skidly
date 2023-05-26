using Skidly.Domain.Aggregates;
using Skidly.Domain.Entities;

namespace Skidly.Application.DTOs;

public static class DtoMapper
{
    public static UserDto UserDto(ApplicationUser user)
    {
        return new UserDto(
            user.UserName,
            user.Email,
            user?.Fullname?.ToString(),
            user?.DateOfBirth?.ToString(),
            user?.Country?.Name);
    }

    public static StudyAreaDto StudyAreaDto(StudyArea area)
    {
        var goals = new List<StudyGoalDto>();

        foreach (var goal in area.Goals)
        {
            var dto = StudyGoalDto(goal);
            goals.Add(dto);
        }

        return new StudyAreaDto(
            area.Name,
            area.Description,
            goals,
            area.GetUserId()
        );
    }

    public static StudyGoalDto StudyGoalDto(StudyGoal goal)
    {
        var pomodoros = new List<PomodoroDto>();

        foreach (var pomodoro in goal.Pomodoros)
        {
            var dto = PomodoroDto(pomodoro);
            pomodoros.Add(dto);
        }
        
        return new StudyGoalDto(
            goal.Name,
            goal.Description,
            goal.Category.ToString(),
            goal.Priority,
            goal.ExpectedLearningTime?.ToString(),
            goal.Deadline?.ToString(),
            goal.IsAchieved,
            pomodoros,
            goal.GetAreaId()
        );
    }

    public static PomodoroDto PomodoroDto(Pomodoro pomodoro)
    {
        return new PomodoroDto(
            pomodoro.Topic.ToString(),
            pomodoro.ExpectedDuration.ToString(),
            pomodoro.Duration.ToString(),
            pomodoro.StartTime?.ToString(),
            pomodoro.FinishTime?.ToString(),
            pomodoro.IsFinished,
            pomodoro.GetGoalId()
        );
    }
}