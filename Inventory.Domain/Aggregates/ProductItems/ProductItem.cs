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

    public ProductItem(Guid id, long productId, string serialNumber)
    {
        Id = id;
        ProductId = productId;
        SerialNumber = serialNumber;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}