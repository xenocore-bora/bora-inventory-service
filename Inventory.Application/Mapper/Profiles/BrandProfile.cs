using AutoMapper;
using Inventory.Application.Results.Brands.Show.Basic;
using Inventory.Domain.Aggregates.Brands;

namespace Inventory.Application.Mapper.Profiles;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<Brand, BasicBrandResult>();
    }
}