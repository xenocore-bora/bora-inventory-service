using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories.Base;

public abstract class BaseRepository<TEntity, TKey> where TEntity : class
{
    protected DbSet<TEntity> Items { get; set; }
    protected PgsqlDbContext Context;

    protected BaseRepository(PgsqlDbContext context)
    {
        Context = context;
        Items = context.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await Items.AddAsync(entity);
    }

    public virtual async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await Items.FindAsync(id);
    }
}