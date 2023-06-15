using Skidly.Domain.Aggregates;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.StudyGoals.CreateGoal;

public class CreateGoalRequestHandler : ICommandHandler<CreateGoalRequest>
{
    private readonly IStudyAreaRepository _areaRepository;
    private readonly IStudyGoalRepository _goalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGoalRequestHandler(IStudyAreaRepository areaRepository, IStudyGoalRepository goalRepository, IUnitOfWork unitOfWork)
    {
        _areaRepository = areaRepository;
        _goalRepository = goalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateGoalRequest request, CancellationToken cancellationToken)
    {
        var area = await _areaRepository.GetAsync(request.AreaId, cancellationToken);

        var goal = new StudyGoal(
            request.Id,
            request.Name,
            request.Description,
            request.Category,
            request.Priority,
            request.ExpectedLearningTime,
            request.Deadline,
            request.IsAchieved,
            area,
            area.Id
        );

        await _goalRepository.AddAsync(goal, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}