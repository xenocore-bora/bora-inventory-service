namespace Inventory.Domain.Interfaces.Repositories.Params.ProductItems;

public class ProductItemParams
{
    public long? ProductId { get; set; }
    public string? SerialNumber { get; set; } = "";
    
    public ProductItemParams() {}
    public ProductItemParams(long productId, string serialNumber)
    {
        ProductId = productId;
        SerialNumber = serialNumber;
    }
}