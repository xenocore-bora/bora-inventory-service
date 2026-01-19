using Inventory.Infrastructure.Persistence;

namespace Inventory.Infrastructure.Seeder.Abstraction.Entity;

public interface IEntitySeeder
{
    int Order { get; }
    Task SeedAsync(PgsqlDbContext context);
}