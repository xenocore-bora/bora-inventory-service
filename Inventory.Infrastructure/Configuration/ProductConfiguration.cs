using Bogus;
using Inventory.Domain.Aggregates;
using Inventory.Domain.Aggregates.Products;
using Inventory.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(200);
        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.UpdatedAt);
        builder.Property(p => p.IsDiscontinued);
        
        // Owned Types
        builder.OwnsOne(p => p.PricePen, ownBuilder =>
        {
            ownBuilder.Ignore(pr => pr.Currency);
            ownBuilder.Property(pr => pr.Amount).HasColumnName("PricePenAmount").HasPrecision(18, 2)
                .ValueGeneratedNever();
        });
        builder.OwnsOne(p => p.PriceUsd, ownBuilder =>
        {
            ownBuilder.Ignore(pr => pr.Currency);
            ownBuilder.Property(pr => pr.Amount).HasColumnName("PriceUsdAmount").HasPrecision(18, 2)
                .ValueGeneratedNever();
        });
    }
}