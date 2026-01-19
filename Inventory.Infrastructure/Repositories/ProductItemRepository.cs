using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class ProductItemRepository : BaseRepository<ProductItem>, IProductItemRepository
{
    public ProductItemRepository(PgsqlDbContext context) : base(context)
    {
    }

    public Task AddAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<(IEnumerable<Product>, int)> PageAsync(int pageIndex = 1, int pageSize = 10, string searchTerm = "")
    {
        throw new NotImplementedException();
    }

    public Task<int> GetProductsTotalCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<(IEnumerable<ProductItem>, int)> PageProductItemsByProductIdAsync(long productId,
        int pageIndex = 1, int pageSize = 10)
    {
        var query = Items.AsNoTracking().Where(pi => pi.ProductId == productId).AsQueryable();
        var totalCount = query.Count();
        var pagedItems = await query.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize).ToListAsync();
        return (pagedItems, totalCount);
    }
}