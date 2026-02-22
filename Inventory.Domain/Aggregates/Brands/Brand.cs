using Inventory.Domain.Aggregates.Brands.Event;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Common.Aggregate;

namespace Inventory.Domain.Aggregates.Brands;

public class Brand : AggregateRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    
    // Relations
    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly(); 
    
    private Brand() {}
    public Brand(Guid id, string name)
    {
        Id = id;
        Name = name;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        AddDomainEvent(new BrandCreatedEvent(Id));
    }
    public Brand(string name)
    {
        Name = name;
        AddDomainEvent(new BrandCreatedEvent(Id));
    }
    public void Update(string name)
    {
        Name = name;
    }
    
    
}