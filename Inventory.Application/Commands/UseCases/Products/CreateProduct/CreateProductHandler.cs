using AutoMapper;
using Inventory.Application.Common.UnitOfWork;
using Inventory.Application.Results.Product.Show.Detailed;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories;

namespace Inventory.Application.Commands.UseCases.Products.CreateProduct;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, DetailedProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DetailedProductResult> HandleAsync(CreateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var newProduct = new Product(command.Name, command.Description, command.PricePen, command.PriceUsd, DateTime.UtcNow, DateTime.UtcNow);
            Console.WriteLine(newProduct.Id);
            await _productRepository.AddAsync(newProduct);
            await _unitOfWork.CommitAsync(cancellationToken);
            newProduct.MarkAsCreated(); // Mark as created after committing to DB
            Console.WriteLine(newProduct.Id);
            return _mapper.Map<DetailedProductResult>(newProduct);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"{e.Message}");
        }
    }
}