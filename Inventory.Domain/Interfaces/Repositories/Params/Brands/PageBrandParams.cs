namespace Inventory.Domain.Interfaces.Repositories.Params.Brands;

public class PageBrandParams : IQueryParams
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }

    public PageBrandParams(int pageIndex, int pageSize, string? searchTerm)
    {
        PageIndex = pageIndex <= 0 ? 1 : pageIndex;
        PageSize = pageSize <= 0 ? 10 : Math.Min(pageSize, 100);
        SearchTerm = searchTerm;
    }
}