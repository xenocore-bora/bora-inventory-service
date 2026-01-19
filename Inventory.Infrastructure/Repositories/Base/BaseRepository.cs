using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories.Base;

public abstract class BaseRepository<TEntity> where TEntity : class
{
    protected DbSet<TEntity> Items { get; set; }
    protected PgsqlDbContext Context;

    protected BaseRepository(PgsqlDbContext context)
    {
        Context = context;
        Items = context.Set<TEntity>();
    }
}