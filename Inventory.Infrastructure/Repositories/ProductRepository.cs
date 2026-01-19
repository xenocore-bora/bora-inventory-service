using Inventory.Domain.Aggregates;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(PgsqlDbContext context) : base(context)
    {
    }

    public async Task<Product?> GetByIdAsync(long id)
    {
        return await Items.Where(p => p.Id == id).FirstOrDefaultAsync(); 
    }

    public async Task<(IEnumerable<Product>, int)> PageAsync(int pageIndex = 1, int pageSize = 10, string searchTerm = "")
    {
        var totalCount = await Items.CountAsync(); 
        var products = await Items.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return (products, totalCount);
    }

    public async Task<int> GetProductsTotalCountAsync()
    {
        return await Items.CountAsync();
    }

    public async Task AddAsync(Product entity)
    {
        await Items.AddAsync(entity);
    }
}