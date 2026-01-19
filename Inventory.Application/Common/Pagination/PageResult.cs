namespace Inventory.Application.Common.Pagination;

public class PageResult<T> where T : class
{
    public IEnumerable<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; }
}