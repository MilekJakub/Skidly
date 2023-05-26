using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class UserNotFoundException : NotFoundException, ISkidlyException
{
    public UserNotFoundException(string id) : base($"The user with id '{id}' was not found.")
    {
    }
}