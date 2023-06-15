namespace Skidly.Shared.Abstractions.Domain;

public abstract class ValidationException : Exception
{
    protected ValidationException(string message) : base(message)
    {
    }
}