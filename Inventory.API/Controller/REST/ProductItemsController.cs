using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inventory.API.Controller.REST;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Product Items API Manager 🚀")]
public class ProductItemsController : ControllerBase
{
    
}