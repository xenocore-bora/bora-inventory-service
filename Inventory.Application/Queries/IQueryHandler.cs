namespace Inventory.Application.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class
{
    Task<TResult> HandleAsync(TQuery query);
}