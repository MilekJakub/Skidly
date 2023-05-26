using System.ComponentModel.DataAnnotations.Schema;

namespace Skidly.Shared.Abstractions.Domain;

[NotMapped]
public abstract class AbstractEntity : IEntity, IEquatable<AbstractEntity>
{
    private readonly List<IDomainEvent> _events = new();
    
    public Guid Id { get; init; }
    
    public IReadOnlyCollection<IDomainEvent> Events => _events;

    protected void AddEvent(IDomainEvent domainEvent) 
        => _events.Add(domainEvent);

    public void ClearEvents() => _events.Clear();

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not AbstractEntity entity)
            return false;

        return entity.Id == Id;
    }

    public bool Equals(AbstractEntity? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Id == Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_events, Id);
    }

    public static bool operator ==(AbstractEntity? first, AbstractEntity? second) 
        => first is not null && second is not null && first.Equals(second);

    public static bool operator !=(AbstractEntity? first, AbstractEntity? second) 
        => !(first == second);
}