using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories.Params.Products;
using Inventory.Domain.Interfaces.Repositories.Read;
using Inventory.Domain.Interfaces.Repositories.Remove;
using Inventory.Domain.Interfaces.Repositories.Update;
using Inventory.Domain.Interfaces.Repositories.Write;

namespace Inventory.Domain.Interfaces.Repositories;

public interface IProductRepository : IRepositoryReader<Product, long>, IRepositoryUpdater<Product>, IRepositoryWriter<Product>, IRepositoryRemover<Product>
{
    Task<(IEnumerable<Product>, int)> PageAsync(PageProductParams @params);
}
