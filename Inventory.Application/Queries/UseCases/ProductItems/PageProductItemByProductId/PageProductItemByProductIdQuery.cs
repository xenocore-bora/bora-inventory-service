using Inventory.Application.Common.Pagination;

namespace Inventory.Application.Queries.UseCases.ProductItems.PageProductItemByProductId;

public class PageProductItemByProductIdQuery : PageRequest
{
    public long ProductId { get; set; }
    public long SerialNumber { get; set; }
}