using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class UsernameAlreadyExistsException : BadRequestException, ISkidlyException
{
    public UsernameAlreadyExistsException(string username) : base($"The user with username '{username}' already exists.")
    {
    }
}