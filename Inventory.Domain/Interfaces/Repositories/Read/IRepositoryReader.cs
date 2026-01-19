using Inventory.Domain.Common.Base;

namespace Inventory.Domain.Interfaces.Repositories.Read;

public interface IRepositoryReader<TClass> where TClass : Entity
{
    Task<TClass?> GetByIdAsync(long id);
    Task<(IEnumerable<TClass>, int)> PageAsync(int pageIndex = 1, int pageSize = 10, string searchTerm = "");
    Task<int> GetProductsTotalCountAsync();
}