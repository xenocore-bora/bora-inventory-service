using Inventory.Application.Common.Pagination;
using Inventory.Application.Results.ProductItem.Show.Basic;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;

public class ProductItemPageByProductIdHandler : IQueryHandler<ProductItemPageByProductIdQuery, PageResult<BasicProductItemResult>>
{
    private readonly IProductItemRepository _productItemRepository;

    public ProductItemPageByProductIdHandler(IProductItemRepository productItemRepository)
    {
        _productItemRepository = productItemRepository;
    }

    public async Task<PageResult<BasicProductItemResult>> HandleAsync(ProductItemPageByProductIdQuery query)
    {
        var (items, a) = await _productItemRepository.PageProductItemsByProductIdAsync(query);
    }
}