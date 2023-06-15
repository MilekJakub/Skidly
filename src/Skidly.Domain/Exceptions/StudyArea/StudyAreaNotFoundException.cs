using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public class StudyAreaNotFoundException : NotFoundException, ISkidlyException
{
    public StudyAreaNotFoundException(string id) : base($"The study area with id '{id}' was not found.")
    {
    }
}