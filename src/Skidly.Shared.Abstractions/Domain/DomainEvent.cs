namespace Skidly.Shared.Abstractions.Domain;

public record DomainEvent
{
    public string Name => GetType().Name;
    public DateTime EventDateTime { get; } = DateTime.Now;
}