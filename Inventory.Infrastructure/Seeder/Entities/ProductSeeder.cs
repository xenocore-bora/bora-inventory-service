using Bogus;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.ValueObject;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;

namespace Inventory.Infrastructure.Seeder.Entities;

public class ProductSeeder : EntitySeeder<Product>
{
    public override int Order => 1;

    protected override void ConfigureFaker()
    {
        Faker.CustomInstantiator(faker =>
        {
            var pricePen = Price.Create(faker.Random.Decimal(0, 1000000), Currency.PEN);
            var priceUsd = Price.Create(faker.Random.Decimal(0, 1000000), Currency.USD);
            return new Product(faker.IndexFaker + 1, faker.Commerce.ProductName(), faker.Commerce.ProductDescription(),
                pricePen, priceUsd);
        });
    }

    protected override IList<Product> GenerateData()
    {
        ConfigureFaker();
        return Faker.UseSeed(3232).Generate(100);
    }
}