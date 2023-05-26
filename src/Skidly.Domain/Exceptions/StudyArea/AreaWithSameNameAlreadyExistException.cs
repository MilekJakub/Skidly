using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.StudyArea;

public sealed class AreaWithSameNameAlreadyExistException : ValidationException, ISkidlyException
{
    public AreaWithSameNameAlreadyExistException() : base("The area with the same name already exist.")
    {
    }
}