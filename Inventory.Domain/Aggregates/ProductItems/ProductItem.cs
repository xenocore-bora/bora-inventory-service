using Inventory.Domain.Aggregates.ProductItems.Event;
using Inventory.Domain.Common.Aggregate;

namespace Inventory.Domain.Aggregates.ProductItems;

public class ProductItem : AggregateRoot
{
    public Guid Id { get; set; }
    public long ProductId { get; set; }
    public string SerialNumber { get; set; }

    private ProductItem()
    {
    }

    public ProductItem(long productId, string serialNumber)
    {
        
        ProductId = productId;
        SerialNumber = serialNumber;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        MarkAsCreated();
    }
    
    private void MarkAsCreated()
    {
        AddDomainEvent(new ProductItemCreatedEvent(Id));
    }

}