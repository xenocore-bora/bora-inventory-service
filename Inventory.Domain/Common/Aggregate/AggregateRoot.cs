using Inventory.Domain.Common.Base;
using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Common.Aggregate;

public class AggregateRoot : Entity
{
    // Attributes
    private readonly List<IDomainEvent> _domainEvents = new();
    
    // Methods
    private void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public IReadOnlyCollection<IDomainEvent> PullDomainEvents()
    {
        var events = _domainEvents.ToList();
        ClearDomainEvents();
        return events;
    }
    
    // Constructor
    protected AggregateRoot() {}
}