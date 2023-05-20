namespace Skidly.Shared.Abstractions.Exceptions;

public class SkidlyException : Exception
{
    protected SkidlyException(string message) : base(message)
    {
    } 
}