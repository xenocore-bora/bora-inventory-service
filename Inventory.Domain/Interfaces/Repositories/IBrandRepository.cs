using Inventory.Domain.Aggregates.Brands;
using Inventory.Domain.Interfaces.Repositories.Params.Brands;
using Inventory.Domain.Interfaces.Repositories.Read;

namespace Inventory.Domain.Interfaces.Repositories;

public interface IBrandRepository : IRepositoryReader<Brand, Guid>
{
    Task<(IEnumerable<Brand>, int)> PageAsync(PageBrandParams @params);
}