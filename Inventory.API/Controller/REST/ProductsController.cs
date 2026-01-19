using System.Net.Mime;
using Inventory.API.Request;
using Inventory.Application.Commands.UseCases.Products.CreateProduct;
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

    public ProductsController(ProductPageableHandler productPageableHandler, GetProductByIdHandler getProductByIdHandler, CreateProductHandler createProductHandler)
    {
        _productPageableHandler = productPageableHandler;
        _getProductByIdHandler = getProductByIdHandler;
        _createProductHandler = createProductHandler;
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
}