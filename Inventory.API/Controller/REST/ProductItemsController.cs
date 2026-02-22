using System.Net.Mime;
using Inventory.API.Request;
using Inventory.Application.Commands.UseCases.ProductItems.CreateProductItem;
using Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventory.API.Controller.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Product Items API Manager 🚀")]
public class ProductItemsController : ControllerBase
{
    private readonly PageProductItemByProductIdHandler _pageProductItemByProductIdHandler;
    private readonly CreateProductItemHandler _createProductItemHandler;

    public ProductItemsController(PageProductItemByProductIdHandler pageProductItemByProductIdHandler, CreateProductItemHandler createProductItemHandler)
    {
        _pageProductItemByProductIdHandler = pageProductItemByProductIdHandler;
        _createProductItemHandler = createProductItemHandler;
    }

    [HttpGet("page/product/{productId:long}")]
    public async Task<IActionResult> GetPageableProductItems([FromRoute] long productId,
        [FromQuery] PageQuery query)
    {
        return Ok(await _pageProductItemByProductIdHandler.HandleAsync(new PageProductItemByProductIdQuery
        {
            ProductId = productId,
            PageIndex = query.PageIndex,
            PageSize = query.PageSize
        }));
    }

    [HttpPost]
    public async Task<IActionResult> GetPageableProductItems([FromBody] CreateProductItemCommand command)
    {
        return Ok(await _createProductItemHandler.HandleAsync(command));
    }
}