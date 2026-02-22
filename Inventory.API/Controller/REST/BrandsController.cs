using System.Net.Mime;
using Inventory.API.Request;
using Inventory.Application.Queries.UseCases.Brands.PageBrands;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventory.API.Controller.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Brands Items API Manager 🚀")]
public class BrandsController : ControllerBase
{
    private readonly PageBrandHandler _pageBrandHandler;

    public BrandsController(PageBrandHandler pageBrandHandler)
    {
        _pageBrandHandler = pageBrandHandler;
    }

    [HttpGet("page")]
    public async Task<IActionResult> GetPageableBrands([FromQuery] PageQuery query)
    {
        Console.WriteLine($"Ah::: {query.SearchTerm}");
        return Ok(await _pageBrandHandler.HandleAsync(new PageBrandQuery
            { PageIndex = query.PageIndex, PageSize = query.PageSize, SearchTerm = query.SearchTerm }));
    }
}