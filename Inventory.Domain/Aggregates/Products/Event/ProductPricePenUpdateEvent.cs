using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductPricePenUpdateEvent(long ProductId, decimal BeforePricePen, decimal AfterPricePen) : IDomainEvent;