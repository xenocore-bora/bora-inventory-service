using Inventory.Application.Common.Command;

namespace Inventory.Application.Commands.UseCases.Products.DiscontinueProduct;

public class DiscontinueProductCommand : ICommand
{
    public long ProductId { get; set; }
}