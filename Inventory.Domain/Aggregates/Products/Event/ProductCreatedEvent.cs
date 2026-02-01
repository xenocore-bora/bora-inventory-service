using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductCreatedEvent(long ProductId) : IDomainEvent;