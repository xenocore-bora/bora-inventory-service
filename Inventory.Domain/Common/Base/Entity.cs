namespace Inventory.Domain.Common.Base;

public abstract class Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    protected Entity() {}
}