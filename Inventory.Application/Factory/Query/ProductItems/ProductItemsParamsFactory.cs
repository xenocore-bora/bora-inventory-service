using Inventory.Application.Commands.UseCases.ProductItems.CreateProductItem;
using Inventory.Domain.Interfaces.Repositories.Params.ProductItems;

namespace Inventory.Application.Factory.Query;

public class ProductItemsParamsFactory : IParamsFactory<CreateProductItemCommand, ProductItemParams>
{
    public ProductItemParams Create(CreateProductItemCommand @params)
    {
        return new ProductItemParams(@params.ProductId, @params.SerialNumber);
    }
}