using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductDescriptionUpdateEvent(long ProductId, string BeforeDescription, string AfterDescription) : IDomainEvent;
