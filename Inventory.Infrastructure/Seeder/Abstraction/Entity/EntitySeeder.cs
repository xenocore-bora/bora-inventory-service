using Bogus;
using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Seeder.Abstraction.Entity;

public abstract class EntitySeeder<TClass> : IEntitySeeder where TClass : class 
{
    protected Faker<TClass> Faker;

    protected EntitySeeder()
    {
        Faker = new Faker<TClass>();
    }

    protected abstract void ConfigureFaker();
    protected abstract IList<TClass> GenerateData();

    public virtual int Order => 0;

    public virtual async Task SeedAsync(PgsqlDbContext context)
    {
        Console.WriteLine("Seeding database...");
        ConfigureFaker();
        var set = context.Set<TClass>();
        if (await set.AnyAsync()) 
            return;
        var items = GenerateData();
        await set.AddRangeAsync(items);
        await context.SaveChangesAsync();
    }
}