using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductNameUpdateEvent(long ProductId, string BeforeName, string AfterName) : IDomainEvent;