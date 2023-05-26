using Skidly.Application.DTOs;
using Skidly.Domain.Exceptions.StudyArea;
using Skidly.Domain.Repositories;
using Skidly.Shared.Abstractions.Queries;

namespace Skidly.Application.StudyAreas.GetArea;

public class GetAreaRequestHandler : IQueryHandler<GetAreaRequest, StudyAreaDto>
{
    private readonly IStudyAreaRepository _areaRepository;

    public GetAreaRequestHandler(IStudyAreaRepository areaRepository)
    {
        _areaRepository = areaRepository;
    }

    public async Task<StudyAreaDto> Handle(GetAreaRequest request, CancellationToken cancellationToken)
    {
        var area = await _areaRepository.GetAsync(request.Id, cancellationToken);

        if (area is null)
        {
            throw new StudyAreaNotFoundException(request.Id.ToString());
        }

        return DtoMapper.StudyAreaDto(area);
    }
}