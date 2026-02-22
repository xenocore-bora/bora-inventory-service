namespace Inventory.Domain.Interfaces.Repositories.Params.Products;

public class PageProductItemParams : IQueryParams
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }

    public PageProductItemParams()
    {
    }

    public PageProductItemParams(int pageIndex, int pageSize, string? searchTerm)
    {
        PageIndex = pageIndex <= 0 ? 1 : pageIndex;
        PageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);
        SearchTerm = searchTerm;
    }
}