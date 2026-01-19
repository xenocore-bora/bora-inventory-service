namespace Inventory.Domain.Interfaces.Repositories.Write;

public interface IRepositoryWriter<in TClass> where TClass: class
{
    Task AddAsync(TClass entity);
}