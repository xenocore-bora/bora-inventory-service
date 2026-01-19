using AutoMapper;
using Inventory.Application.Results.Show.Detailed;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Queries.UseCases.Products.GetDetailedProductInfoById;

public class GetProductByIdHandler : IQueryHandler<GetProductByIdQuery, DetailedProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<DetailedProductResult> HandleAsync(GetProductByIdQuery query)
    {
        var existingProduct = await _productRepository.GetByIdAsync(query.ProductId);
        if (existingProduct == null)
        {
            throw new KeyNotFoundException($"Product with {query.ProductId} not found");
        }
        return _mapper.Map<DetailedProductResult>(existingProduct);
    }
}