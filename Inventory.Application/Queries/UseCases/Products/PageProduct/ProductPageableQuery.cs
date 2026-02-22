using Inventory.Application.Common.Pagination;

namespace Inventory.Application.Queries.UseCases.Products.PageProduct;

public class ProductPageableQuery : PageRequest
{
    public bool? IsDiscontinued { get; set; }
}