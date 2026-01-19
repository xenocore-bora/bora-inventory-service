namespace Inventory.Application.Common.Pagination;

public class PageRequest
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SearchTerm { get; set; } = "";
}