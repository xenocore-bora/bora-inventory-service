using AutoMapper;
using Inventory.Application.Common.Pagination;
using Inventory.Application.Factory.Query.Brands;
using Inventory.Application.Results.Brands.Show.Basic;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Queries.UseCases.Brands.PageBrands;

public class PageBrandHandler : IQueryHandler<PageBrandQuery, PageResult<BasicBrandResult>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly PageBrandsParamsFactory _pageBrandsParamsFactory;

    public PageBrandHandler(IBrandRepository brandRepository, IMapper mapper, PageBrandsParamsFactory pageBrandsParamsFactory)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _pageBrandsParamsFactory = pageBrandsParamsFactory;
    }

    public async Task<PageResult<BasicBrandResult>> HandleAsync(PageBrandQuery query)
    {
        Console.WriteLine($"Ah::: {query.SearchTerm}");
        var (items, totalCount) = await _brandRepository.PageAsync(_pageBrandsParamsFactory.Create(query));
        var mappedItems = _mapper.Map<IEnumerable<BasicBrandResult>>(items);
        return new PageResult<BasicBrandResult>
        {
            Items = mappedItems,
            TotalCount = totalCount
        };
    }
}