using Inventory.Application.Common.Command;

namespace Inventory.Application.Commands.UseCases.Products.UpdateProduct;

public class UpdateProductCommand : ICommand
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PricePen { get; set; }
    public decimal PriceUsd { get; set; }  
}