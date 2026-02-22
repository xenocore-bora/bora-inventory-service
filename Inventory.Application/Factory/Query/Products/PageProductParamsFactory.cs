using Inventory.Application.Queries.UseCases.Products.PageProduct;
using Inventory.Domain.Interfaces.Repositories.Params.Products;

namespace Inventory.Application.Factory.Query;

public class PageProductParamsFactory : IParamsFactory<ProductPageableQuery, PageProductParams>
{
    public PageProductParams Create(ProductPageableQuery @params)
    {
        return new PageProductParams(@params.PageIndex, @params.PageSize, @params.SearchTerm);
    }
}