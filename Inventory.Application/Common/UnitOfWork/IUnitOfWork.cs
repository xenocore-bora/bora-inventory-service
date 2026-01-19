namespace Inventory.Application.Common.UnitOfWork;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}