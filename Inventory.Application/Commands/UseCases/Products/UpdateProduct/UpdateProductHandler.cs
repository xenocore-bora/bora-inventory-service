using AutoMapper;
using Inventory.Application.Common.UnitOfWork;
using Inventory.Application.Results.Show.Detailed;
using Inventory.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace Inventory.Application.Commands.UseCases.Products.UpdateProduct;

public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, DetailedProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork,
        ILogger<UpdateProductHandler> logger)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<DetailedProductResult> HandleAsync(UpdateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var existingProduct = await _productRepository.GetByIdAsync(command.Id);
        if (existingProduct == null)
            throw new KeyNotFoundException("Product not found");

        try
        {
            existingProduct.Update(command.Name, command.Description, command.PricePen, command.PriceUsd);
            _productRepository.Update(existingProduct);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(
                e,
                "Error updating product {ProductId}",
                command.Id);
            throw;
        }

        return _mapper.Map<DetailedProductResult>(existingProduct);
    }
}