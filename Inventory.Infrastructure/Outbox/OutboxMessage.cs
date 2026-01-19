using System.Text.Json;
using Inventory.Domain.Events;

namespace Inventory.Infrastructure.Outbox;

public sealed class OutboxMessage
{
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
    public string Type { get; set; } = null!;
    public string Payload { get; set; } = null!;
    public bool Processed { get; set; }

    public static OutboxMessage Create(IDomainEvent domainEvent)
    {
        return new OutboxMessage
        {
            Id = Guid.NewGuid(),
            Type = domainEvent.GetType().Name,
            Payload = JsonSerializer.Serialize(domainEvent),
            OccurredOn = DateTime.UtcNow,
            Processed = false
        };
    }
    
    public void MarkAsProcessed()
    {
        Processed = true;
        OccurredOn = DateTime.UtcNow;
    }

    public IDomainEvent ToDomainEvent()
    {
        var type = System.Type.GetType(Type, throwOnError: true);
        var domainEvent = (IDomainEvent)JsonSerializer.Deserialize(Payload, type!)!;
        return domainEvent;
    }
}