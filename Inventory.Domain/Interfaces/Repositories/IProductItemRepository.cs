using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories.Read;
using Inventory.Domain.Interfaces.Repositories.Write;

namespace Inventory.Domain.Interfaces.Repositories;

public interface IProductItemRepository : IRepositoryWriter<Product>, IRepositoryReader<Product>
{
    Task<(IEnumerable<ProductItem>, int)> PageProductItemsByProductIdAsync(long productId, int pageIndex = 1, int pageSize = 10);
}