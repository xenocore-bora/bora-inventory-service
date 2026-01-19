using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Seeder.Abstraction.Entity;

namespace Inventory.Infrastructure.Seeder.Abstraction;

public class DatabaseSeeder
{
    private readonly PgsqlDbContext _context;
    private readonly IEnumerable<IEntitySeeder> _seeders;

    public DatabaseSeeder(IEnumerable<IEntitySeeder> seeders, PgsqlDbContext context)
    {
        _seeders = seeders;
        _context = context;
    }

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var orderedSeeders = _seeders.OrderBy(s => s.Order).ToList();
            foreach (var orderedSeeder in orderedSeeders)
            {
                await orderedSeeder.SeedAsync(_context);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Something went wrong seeding the database: {e.Message}"); 
        }
    }
}