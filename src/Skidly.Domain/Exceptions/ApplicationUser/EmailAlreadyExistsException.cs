using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class EmailAlreadyExistsException : BadRequestException, ISkidlyException
{
    public EmailAlreadyExistsException(string email) : base($"The user with email '{email}' already exists.")
    {
    }
}