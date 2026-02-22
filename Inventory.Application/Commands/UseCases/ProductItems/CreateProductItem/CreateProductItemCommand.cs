using Inventory.Application.Common.Command;

namespace Inventory.Application.Commands.UseCases.ProductItems.CreateProductItem;

public class CreateProductItemCommand : ICommand
{
    public long ProductId { get; set; }
    public string SerialNumber { get; set; }
}