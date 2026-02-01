using System.Net.Mime;
using Inventory.API.Request;
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

    public ProductItemsController(PageProductItemByProductIdHandler pageProductItemByProductIdHandler)
    {
        _pageProductItemByProductIdHandler = pageProductItemByProductIdHandler;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetPageableProductItems([FromQuery(Name = "product_id")] long productId,
        [FromQuery] PageQuery query)
    {
        return Ok(await _pageProductItemByProductIdHandler.HandleAsync(new PageProductItemByProductIdQuery
        {
            ProductId = productId,
            PageIndex = query.PageIndex,
            PageSize = query.PageSize
        }));
    }
}