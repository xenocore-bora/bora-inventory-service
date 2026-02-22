using AutoMapper;
using Inventory.Application.Common.Pagination;
using Inventory.Application.Factory.Query;
using Inventory.Application.Results.Show.Basic;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Domain.Interfaces.Repositories.Params.Products;

namespace Inventory.Application.Queries.UseCases.Products.PageProduct;

public sealed class ProductPageableHandler : IQueryHandler<ProductPageableQuery, PageResult<BasicProductResult>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    // Factories
    private readonly PageProductParamsFactory _pageProductFactory;


    public ProductPageableHandler(IProductRepository productRepository, IMapper mapper,
        PageProductParamsFactory pageProductFactory)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _pageProductFactory = pageProductFactory;
    }

    public async Task<PageResult<BasicProductResult>> HandleAsync(ProductPageableQuery query)
    {
        var (items, totalCount) = await _productRepository.PageAsync(_pageProductFactory.Create(query));
        var mappedItems = _mapper.Map<IEnumerable<BasicProductResult>>(items);
        return new PageResult<BasicProductResult>
        {
            Items = mappedItems,
            TotalCount = totalCount
        };
    }
}