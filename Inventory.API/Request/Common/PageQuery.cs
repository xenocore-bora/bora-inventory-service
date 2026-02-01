using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Request;

public class PageQuery
{
    [FromQuery(Name = "page_index")] public int PageIndex { get; set; } = 1;
    [FromQuery(Name = "page_size")] public int PageSize { get; set; } = 10;
    [FromQuery(Name = "search_term")] public string SearchTerm { get; set; } = "";
}