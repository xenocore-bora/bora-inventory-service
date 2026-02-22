using Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;
using Inventory.Domain.Interfaces.Repositories.Params.Products;

namespace Inventory.Application.Factory.Query;

public class PageProductItemParamsFactory : IParamsFactory<PageProductItemByProductIdQuery, PageProductItemParams>
{
    public PageProductItemParams Create(PageProductItemByProductIdQuery @params)
    {
        return new PageProductItemParams(@params.PageIndex, @params.PageSize, @params.SearchTerm);
    }
}