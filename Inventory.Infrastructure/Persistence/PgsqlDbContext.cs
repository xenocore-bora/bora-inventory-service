using Inventory.Domain.Aggregates;
using Inventory.Domain.Aggregates.Products;
using Inventory.Infrastructure.Extensions;
using Inventory.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Persistence;

public class PgsqlDbContext : DbContext
{
    // Infrastructure Entities
    public DbSet<OutboxMessage> OutboxMessages { get; set; }
    
    // Domain Entities
    public DbSet<Product> Products { get; set; }
    
    
    public PgsqlDbContext(DbContextOptions<PgsqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PgsqlDbContext).Assembly);
        // Not using this for now
        modelBuilder.ConvertToSnakeCase();
        base.OnModelCreating(modelBuilder);
    }
}