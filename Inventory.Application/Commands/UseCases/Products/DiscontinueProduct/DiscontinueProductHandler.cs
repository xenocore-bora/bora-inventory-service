using AutoMapper;
using Inventory.Application.Common.UnitOfWork;
using Inventory.Application.Results.Product.Show.Detailed;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Commands.UseCases.Products.DiscontinueProduct;

public class DiscontinueProductHandler : ICommandHandler<DiscontinueProductCommand, DetailedProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DiscontinueProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<DetailedProductResult> HandleAsync(DiscontinueProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingProduct = await _productRepository.GetByIdAsync(command.ProductId);
        if (existingProduct == null)

            throw new KeyNotFoundException($"Product does not exist");
        try
        {
            existingProduct.Discontinue();
            await _unitOfWork.CommitAsync(cancellationToken);
            return new DetailedProductResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}