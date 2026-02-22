using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Domain.Interfaces.Repositories.Params.ProductItems;
using Inventory.Domain.Interfaces.Repositories.Read;
using Inventory.Domain.Interfaces.Repositories.Write;

namespace Inventory.Domain.Interfaces.Repositories;

public interface IProductItemRepository : IRepositoryWriter<ProductItem>, IRepositoryReader<ProductItem, long>
{
    Task<(IEnumerable<ProductItem>, int)> PageProductItemsByProductIdAsync(long productId, int pageIndex = 1, int pageSize = 10);
    Task<ProductItem?> GetProductBySerialNumber(ProductItemParams @params);
    Task<bool> ExistsProductBySerialNumber(ProductItemParams @params);
}