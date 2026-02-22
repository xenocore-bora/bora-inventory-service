using Inventory.Application.Queries.UseCases.Brands.PageBrands;
using Inventory.Domain.Interfaces.Repositories.Params.Brands;

namespace Inventory.Application.Factory.Query.Brands;

public class PageBrandsParamsFactory : IParamsFactory<PageBrandQuery, PageBrandParams>
{
    public PageBrandParams Create(PageBrandQuery @params)
    {
        return new PageBrandParams(@params.PageIndex, @params.PageSize, @params.SearchTerm);
    }
}