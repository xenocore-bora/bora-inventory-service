namespace Inventory.Domain.Interfaces.Repositories.Remove;

public interface IRepositoryRemover<TEntity>
{
    void Remove(TEntity entity);
}