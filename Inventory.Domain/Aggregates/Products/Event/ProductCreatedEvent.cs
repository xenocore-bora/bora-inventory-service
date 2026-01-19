using Inventory.Domain.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductCreatedEvent(long ProductId) : IDomainEvent;