using Bogus;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.ValueObject;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;
using Inventory.Infrastructure.Seeder.Constants.Brands;

namespace Inventory.Infrastructure.Seeder.Entities;

public class ProductSeeder : EntitySeeder<Product>
{
    public override int Order => 2;
    protected override string TableName => "Products";

    protected override void ConfigureFaker()
    {
        Faker.CustomInstantiator(faker =>
        {
            var pricePen = Price.Create(faker.Random.Decimal(0, 1000000), Currency.PEN);
            var priceUsd = Price.Create(faker.Random.Decimal(0, 1000000), Currency.USD);
            var brandId = BrandConstants.BrandIds[Random.Shared.Next(0, 20)];
            return new Product(faker.Commerce.ProductName(), faker.Commerce.ProductDescription(),
                pricePen, priceUsd, brandId);
        });
    }

    protected override IList<Product> GenerateData()
    {
        ConfigureFaker();
        return Faker.UseSeed(3232).Generate(100);
    }
}