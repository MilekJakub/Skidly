namespace Skidly.Shared.Abstractions.Domain;

public abstract record DomainEvent : IDomainEvent
{
    public string Name => GetType().Name;
    public DateTime EventDateTime { get; } = DateTime.Now;
}