namespace Inventory.Domain.Interfaces.Repositories.Params;

public interface IQueryParams
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? SearchTerm { get; set; }
}