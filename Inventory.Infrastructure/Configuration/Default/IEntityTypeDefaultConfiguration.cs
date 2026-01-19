using Bogus;
using Inventory.Domain.Aggregates.ProductItems;

namespace Inventory.Infrastructure.Configuration.Default;

public interface IEntityTypeDefaultConfiguration<TClass> where TClass : class
{
    protected Faker<TClass> Faker { get; set; }
    void ConfigureFaker();
    IList<TClass> GenerateData();
}