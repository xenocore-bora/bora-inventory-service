using AutoMapper;
using Inventory.Application.Common.Pagination;
using Inventory.Application.Results.ProductItem.Show.Basic;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;

public class
    PageProductItemByProductIdHandler : IQueryHandler<PageProductItemByProductIdQuery,
    PageResult<BasicProductItemResult>>
{
    private readonly IProductItemRepository _productItemRepository;
    private readonly IMapper _mapper;

    public PageProductItemByProductIdHandler(IProductItemRepository productItemRepository, IMapper mapper)
    {
        _productItemRepository = productItemRepository;
        _mapper = mapper;
    }

    public async Task<PageResult<BasicProductItemResult>> HandleAsync(PageProductItemByProductIdQuery query)
    {
        var (items, totalCount) =
            await _productItemRepository.PageProductItemsByProductIdAsync(query.ProductId, query.PageIndex,
                query.PageSize);

        var mappedItems = _mapper.Map<IEnumerable<BasicProductItemResult>>(items);

        return new PageResult<BasicProductItemResult>
        {
            Items = mappedItems, TotalCount = totalCount
        };
    }
}