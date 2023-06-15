using Skidly.Application.Services;
using Skidly.Domain.Aggregates;
using Skidly.Domain.Exceptions.ApplicationUser;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions.Commands;

namespace Skidly.Application.StudyAreas.CreateArea;

public class CreateAreaRequestHandler : ICommandHandler<CreateAreaRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IStudyAreaRepository _areaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAreaRequestHandler(IUserRepository userRepository, IStudyAreaRepository areaRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _areaRepository = areaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateAreaRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            throw new UserNotFoundException(request.UserId);
        }
        
        var area = new StudyArea(request.Id, request.Name, request.Description, user);
        
        await _areaRepository.AddAsync(area, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}