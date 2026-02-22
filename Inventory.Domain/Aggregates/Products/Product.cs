using Inventory.Domain.Aggregates.Brands;
using Inventory.Domain.Aggregates.Products.Event;
using Inventory.Domain.Common.Aggregate;
using Inventory.Domain.ValueObject;

namespace Inventory.Domain.Aggregates.Products;

public class Product : AggregateRoot
{
    public long Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Price? PricePen { get; set; }
    public Price? PriceUsd { get; set; }
    public bool IsDiscontinued { get; set; }
    
    // Foreign Key
    public Guid BrandId { get; set; }
    public Brand? Brand { get; set; }

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
        Console.WriteLine($"1: Creating product {Id}");
        // AddDomainEvent(new ProductCreatedEvent(Id));
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
        Console.WriteLine($"2: Creating product {Id}");
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
        Console.WriteLine($"3: Creating product {Id}");
    }

    public Product(string name, string description, Price pricePen, Price priceUsd, Guid brandId)
    {
        Name = name;
        Description = description;
        PricePen = pricePen;
        PriceUsd = priceUsd;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        BrandId = brandId;
        Console.WriteLine($"4: Creating product {Id}");
    }

    public void Update(string name, string description, decimal pricePen, decimal priceUsd)
    {
        Console.WriteLine($"Updating product {Id}");
        if (Name != name)
        {
            AddDomainEvent(new ProductNameUpdateEvent(Id, Name, name));
            Name = name;
        }

        if (Description != description)
        {
            AddDomainEvent(new ProductDescriptionUpdateEvent(Id, Description, description));
            Description = description;
        }

        if (PricePen != null)
        {
            if (PricePen.Amount != pricePen)
            {
                AddDomainEvent(new ProductPricePenUpdateEvent(Id, PricePen.Amount, pricePen));
                PricePen = Price.Create(pricePen, Currency.PEN);
            }
        }
        
        if (PriceUsd != null)
        {
            if (PriceUsd.Amount != priceUsd)
            {
                AddDomainEvent(new ProductPriceUsdUpdateEvent(Id, PriceUsd.Amount, priceUsd));
                PriceUsd = Price.Create(pricePen, Currency.USD);
            }
        }
        
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void Discontinue()
    {
        IsDiscontinued = true;
    }

    public void MarkAsCreated()
    {
        AddDomainEvent(new ProductCreatedEvent(Id));
    }
}