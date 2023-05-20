namespace Skidly.Shared.Abstractions.Domain;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _events = new();
    
    public IEnumerable<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent domainEvent) 
        => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear(); 
}