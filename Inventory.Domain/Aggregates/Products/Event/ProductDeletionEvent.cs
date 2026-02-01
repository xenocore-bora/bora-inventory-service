using Inventory.Domain.Common.Events;

namespace Inventory.Domain.Aggregates.Products.Event;

public record ProductDeletionEvent(long ProductId, bool BeforeIsDiscontinued, bool AfterIsDiscontinued) : IDomainEvent;