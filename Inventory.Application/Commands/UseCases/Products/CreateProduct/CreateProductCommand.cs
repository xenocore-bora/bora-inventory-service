using Inventory.Application.Common.Command;

namespace Inventory.Application.Commands.UseCases.Products.CreateProduct;

public class CreateProductCommand : ICommand
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal PricePen { get; set; }
    public decimal PriceUsd { get; set; }
}