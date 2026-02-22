using AutoMapper;
using Inventory.Application.Results.Product.Show.Detailed;
using Inventory.Application.Results.Show.Basic;
using Inventory.Domain.Aggregates;
using Inventory.Domain.Aggregates.Products;

namespace Inventory.Application.Mapper.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        // Domain to Result
        CreateMap<Product, BasicProductResult>()
            .ForMember(result => result.PricePen, expression => expression.MapFrom(product => product.PricePen!.Amount))
            .ForMember(result => result.PriceUsd, expression => expression.MapFrom(product => product.PriceUsd!.Amount));
        
        CreateMap<Product, DetailedProductResult>()
            .ForMember(result => result.PricePen, expression => expression.MapFrom(product => product.PricePen!.Amount))
            .ForMember(result => result.PriceUsd, expression => expression.MapFrom(product => product.PriceUsd!.Amount))
            .ForMember(result => result.BrandName, expression => expression.MapFrom(product => product.Brand!.Name));
        
        // Command to Domain
        
    }
    
    
}