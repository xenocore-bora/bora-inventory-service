using Inventory.Domain.Aggregates.Brands;
using Inventory.Domain.Interfaces.Repositories;
using Inventory.Domain.Interfaces.Repositories.Params.Brands;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Repositories;

public class BrandRepository : BaseRepository<Brand, Guid>, IBrandRepository
{
    public BrandRepository(PgsqlDbContext context) : base(context)
    {
    }

    public override async Task<Brand?> GetByIdAsync(Guid id)
    {
        return await Items.Where(b => b.Id == id).FirstOrDefaultAsync();
    }

    public Task<int> GetTotalCountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<(IEnumerable<Brand>, int)> PageAsync(PageBrandParams @params)
    {
        Console.WriteLine(@params.SearchTerm);
        var query = Items
            .Where(brand => brand.Name.Contains(@params.SearchTerm!)).AsQueryable();
        var totalCount = await query.CountAsync();
        var brands = await query.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
            .OrderBy(b => b.Id).ToListAsync();
        return (brands, totalCount);
    }
}