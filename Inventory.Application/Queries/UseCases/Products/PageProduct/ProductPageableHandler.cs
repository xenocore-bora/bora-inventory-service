using AutoMapper;
using Inventory.Application.Common.Pagination;
using Inventory.Application.Results.Show.Basic;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Queries.UseCases.Products.PageProduct;

public sealed class ProductPageableHandler : IQueryHandler<ProductPageableQuery, PageResult<BasicProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductPageableHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<PageResult<BasicProductResult>> HandleAsync(ProductPageableQuery query)
    {
        var (items, totalCount) = await _productRepository.PageAsync(query.PageIndex, query.PageSize, query.SearchTerm);
        var mappedItems = _mapper.Map<IEnumerable<BasicProductResult>>(items);
        return new PageResult<BasicProductResult>
        {
            Items = mappedItems,
            TotalCount = totalCount
        };
    }
}