namespace Skidly.Shared.Abstractions.Domain;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message) : base(message)
    {
    }
}