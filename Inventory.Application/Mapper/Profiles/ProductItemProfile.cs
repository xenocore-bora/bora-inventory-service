using AutoMapper;
using Inventory.Application.Results.ProductItem.Show.Basic;
using Inventory.Application.Results.ProductItem.Show.Detailed;
using Inventory.Domain.Aggregates.ProductItems;

namespace Inventory.Application.Mapper.Profiles;

public class ProductItemProfile : Profile
{
    public ProductItemProfile()
    {
        CreateMap<ProductItem, DetailedProductItemResult>();
        CreateMap<ProductItem, BasicProductItemResult>();
    }
}