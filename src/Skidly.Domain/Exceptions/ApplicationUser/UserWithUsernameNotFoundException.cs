using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class UserWithUsernameNotFoundException : NotFoundException, ISkidlyException
{
    public UserWithUsernameNotFoundException(string username) : base($"The user with username '{username}' was not found.")
    {
    }
}