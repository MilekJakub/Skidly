using Skidly.Application.DTOs;
using Skidly.Domain.Exceptions.StudyGoal;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.StudyGoals.GetGoal;

public class GetGoalRequestHandler : IQueryHandler<GetGoalRequest, StudyGoalDto>
{
    private readonly IStudyGoalRepository _goalRepository;

    public GetGoalRequestHandler(IStudyGoalRepository goalRepository)
    {
        _goalRepository = goalRepository;
    }

    public async Task<StudyGoalDto> Handle(GetGoalRequest request, CancellationToken cancellationToken)
    {
        var goal = await _goalRepository.GetAsync(request.Id, cancellationToken);

        if (goal is null)
        {
            throw new GoalNotFoundException();
        }

        var dto = DtoMapper.StudyGoalDto(goal);
        return dto;
    }
}