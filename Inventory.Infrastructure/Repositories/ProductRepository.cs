using Inventory.Domain.Aggregates;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Domain.Interfaces.Repositories.Params.Products;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product, long>, IProductRepository
{
    public ProductRepository(PgsqlDbContext context) : base(context)
    {
    }

    public override async Task<Product?> GetByIdAsync(long id)
    {
        return await Items
            .Where(p => p.Id == id)
            .Include(p => p.Brand)
            .FirstOrDefaultAsync();
    }

    public async Task<(IEnumerable<Product>, int)> PageAsync(PageProductParams @params)
    {
        var totalCount = await Items.CountAsync();
        var products = await Items
            .Where(p => p.Name.Contains(@params.SearchTerm) || p.Description.Contains(@params.SearchTerm))
            .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize).ToListAsync();
        return (products, totalCount);
    }


    public async Task<int> GetTotalCountAsync()
    {
        return await Items.CountAsync();
    }

    public override async Task AddAsync(Product entity)
    {
        await Items.AddAsync(entity);
    }

    public void Update(Product entity)
    {
        Items.Update(entity);
    }

    public void Remove(Product entity)
    {
        Items.Remove(entity);
    }
}