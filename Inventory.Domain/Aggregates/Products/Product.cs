using Inventory.Domain.Aggregates.Products.Event;
using Inventory.Domain.Common.Aggregate;
using Inventory.Domain.ValueObject;

namespace Inventory.Domain.Aggregates.Products;

public class Product : AggregateRoot
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Price? PricePen { get; set; }
    public Price? PriceUsd { get; set; }

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Product(long id, string name, string description, decimal pricePen, decimal priceUsd, DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        PricePen = Price.Create(pricePen, Currency.PEN);
        PriceUsd = Price.Create(priceUsd, Currency.USD);
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        AddDomainEvent(new ProductCreatedEvent(Id));
    }

    public Product(string name, string description, decimal pricePen, decimal priceUsd, DateTime createdAt,
        DateTime updatedAt)
    {
        Name = name;
        Description = description;
        PricePen = Price.Create(pricePen, Currency.PEN);
        PriceUsd = Price.Create(priceUsd, Currency.USD);
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        AddDomainEvent(new ProductCreatedEvent(Id));
    }

    public Product(long id, string name, string description, Price pricePen, Price priceUsd)
    {
        Id = id;
        Name = name;
        Description = description;
        PricePen = pricePen;
        PriceUsd = priceUsd;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        AddDomainEvent(new ProductCreatedEvent(Id));
    }
}