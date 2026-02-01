using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductPriceUsdUpdateEvent(long ProductId, decimal BeforePriceUsd, decimal AfterPriceUsd) : IDomainEvent;