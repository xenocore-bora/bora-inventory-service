using AutoMapper;
using Inventory.Application.Common.UnitOfWork;
using Inventory.Application.Factory.Query;
using Inventory.Application.Results.ProductItem.Show.Detailed;
using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Commands.UseCases.ProductItems.CreateProductItem;

public class CreateProductItemHandler : ICommandHandler<CreateProductItemCommand, DetailedProductItemResult>
{
    private readonly IProductItemRepository _productItemRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductItemsParamsFactory _productItemParamsFactory;
    
    public CreateProductItemHandler(IProductItemRepository productItemRepository, IMapper mapper,
        IUnitOfWork unitOfWork, ProductItemsParamsFactory productItemParamsFactory)
    {
        _productItemRepository = productItemRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productItemParamsFactory = productItemParamsFactory;
    }

    public async Task<DetailedProductItemResult> HandleAsync(CreateProductItemCommand command,
        CancellationToken cancellationToken = default)
    {
        // Creating params for a query.
        var @params = _productItemParamsFactory.Create(command);
        
        // Checking if a product with a serial number already exists.
        var existingSerialNumber = await _productItemRepository.ExistsProductBySerialNumber(@params);
        if (existingSerialNumber)
            throw new Exception($"Product with serial number {command.SerialNumber} already exists");
        
        // Creating product item.
        var newProductItem = new ProductItem(command.ProductId, command.SerialNumber);
        await _productItemRepository.AddAsync(newProductItem);
        await _unitOfWork.CommitAsync(cancellationToken);
        return _mapper.Map<DetailedProductItemResult>(newProductItem);
    }
}