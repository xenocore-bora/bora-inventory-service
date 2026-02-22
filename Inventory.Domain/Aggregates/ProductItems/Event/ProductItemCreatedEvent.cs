using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.ProductItems.Event;

public record ProductItemCreatedEvent(Guid ProductItemId) : IDomainEvent;