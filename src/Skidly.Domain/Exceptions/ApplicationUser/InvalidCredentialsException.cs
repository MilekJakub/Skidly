using Skidly.Shared.Abstractions.Domain;
using Skidly.Shared.Abstractions.Exceptions;

namespace Skidly.Domain.Exceptions.ApplicationUser;

public class InvalidCredentialsException : BadRequestException, ISkidlyException
{
    public InvalidCredentialsException() : base("Invalid username or password.")
    {
    }
}