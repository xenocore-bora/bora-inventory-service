namespace Inventory.API.Request.Products;

public class UpdateProductRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PricePen { get; set; }
    public decimal PriceUsd { get; set; }  
}