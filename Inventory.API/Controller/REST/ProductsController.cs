using System.Net.Mime;
using Inventory.API.Request;
using Inventory.API.Request.Products;
using Inventory.Application.Commands.UseCases.Products.CreateProduct;
using Inventory.Application.Commands.UseCases.Products.DiscontinueProduct;
using Inventory.Application.Commands.UseCases.Products.UpdateProduct;
using Inventory.Application.Queries.UseCases.Products.GetDetailedProductInfoById;
using Inventory.Application.Queries.UseCases.Products.PageProduct;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventory.API.Controller.REST;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/[controller]")]
[SwaggerTag("Products API Manager 🚀")]
public class ProductsController : ControllerBase
{
    private readonly ProductPageableHandler _productPageableHandler;
    private readonly GetProductByIdHandler _getProductByIdHandler;
    private readonly CreateProductHandler _createProductHandler;
    private readonly UpdateProductHandler _updateProductHandler;
    private readonly DiscontinueProductHandler _discontinueProductHandler;

    public ProductsController(ProductPageableHandler productPageableHandler,
        GetProductByIdHandler getProductByIdHandler, CreateProductHandler createProductHandler,
        UpdateProductHandler updateProductHandler, DiscontinueProductHandler discontinueProductHandler)
    {
        _productPageableHandler = productPageableHandler;
        _getProductByIdHandler = getProductByIdHandler;
        _createProductHandler = createProductHandler;
        _updateProductHandler = updateProductHandler;
        _discontinueProductHandler = discontinueProductHandler;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetPageableProducts([FromQuery] PageQuery query)
    {
        return Ok(await _productPageableHandler.HandleAsync(new ProductPageableQuery
            { PageIndex = query.PageIndex, PageSize = query.PageSize, SearchTerm = query.SearchTerm }));
    }

    [HttpGet("{productId:long}")]
    public async Task<IActionResult> GetProduct([FromRoute] long productId)
    {
        return Ok(await _getProductByIdHandler.HandleAsync(new GetProductByIdQuery(productId)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        return Ok(await _createProductHandler.HandleAsync(command));
    }

    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] long productId, [FromBody] UpdateProductRequest request)
    {
        var updateProductCommand = new UpdateProductCommand  {
            Id = productId,
            Name = request.Name,
            Description = request.Description,
            PricePen = request.PricePen,
            PriceUsd = request.PriceUsd
        };
        
        return Ok(await _updateProductHandler.HandleAsync(updateProductCommand));
    }

    [HttpPost("{productId}/discontinue")]
    public async Task<IActionResult> Discontinue([FromRoute] long productId)
    {
        var discontinueCommand = new DiscontinueProductCommand { ProductId = productId };
        return Ok(await _discontinueProductHandler.HandleAsync(discontinueCommand));
    }
}