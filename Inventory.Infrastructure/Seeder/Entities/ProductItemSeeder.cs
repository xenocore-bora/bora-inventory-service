using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;

namespace Inventory.Infrastructure.Seeder.Entities;

public class ProductItemSeeder : EntitySeeder<ProductItem>
{
    public override int Order => 2;
    protected override void ConfigureFaker()
    {
        Faker.CustomInstantiator(f => new ProductItem(f.Random.Guid(), f.Random.Long(1, 100), f.Random.AlphaNumeric(10)));
    }

    protected override IList<ProductItem> GenerateData()
    {
        ConfigureFaker();
        return Faker.UseSeed(3232).Generate(100);
    }
}