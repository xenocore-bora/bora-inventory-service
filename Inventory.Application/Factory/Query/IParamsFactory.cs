namespace Inventory.Application.Factory.Query;

public interface IParamsFactory<in TParams, out TQuery> where TQuery : class
{
    TQuery Create(TParams @params);
}