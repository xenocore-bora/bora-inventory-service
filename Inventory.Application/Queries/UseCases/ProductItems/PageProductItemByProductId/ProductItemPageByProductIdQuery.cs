using Inventory.Application.Common.Pagination;

namespace Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;

public class ProductItemPageByProductIdQuery : PageRequest
{
    public long ProductId { get; }
    public long SerialNumber { get; }
}