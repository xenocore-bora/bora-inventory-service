using Bogus;
using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Seeder.Abstraction.Entity;

public abstract class EntitySeeder<TClass> : IEntitySeeder where TClass : class 
{
    protected Faker<TClass> Faker;
    protected abstract string TableName { get; }

    protected EntitySeeder()
    {
        Faker = new Faker<TClass>();
    }

    protected virtual void ConfigureFaker()
    {
        // Default faker configuration
    }

    protected abstract IList<TClass> GenerateData();

    public virtual int Order => 0;

    public virtual async Task SeedAsync(PgsqlDbContext context)
    {
        Console.WriteLine($"Table '{TableName}' is being seeded...");
        ConfigureFaker();
        var set = context.Set<TClass>();
        if (await set.AnyAsync()) 
            return;
        var items = GenerateData();
        await set.AddRangeAsync(items);
        await context.SaveChangesAsync();
    }
}