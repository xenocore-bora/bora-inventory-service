using Inventory.Domain.Common.Base;

namespace Inventory.Domain.Interfaces.Repositories.Read;

public interface IRepositoryReader<TClass, in TKey> where TClass : Entity
{
    Task<TClass?> GetByIdAsync(TKey key);
    Task<int> GetTotalCountAsync();
}