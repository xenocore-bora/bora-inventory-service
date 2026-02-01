namespace Inventory.Domain.Interfaces.Repositories.Update;

public interface IRepositoryUpdater<TClass>
{
    void Update(TClass entity);
}