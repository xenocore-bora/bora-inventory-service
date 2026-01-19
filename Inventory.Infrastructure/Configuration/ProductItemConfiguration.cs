using Bogus;
using Inventory.Domain.Aggregates.ProductItems;
using Inventory.Domain.Aggregates.Products;
using Inventory.Infrastructure.Configuration.Default;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Configuration;

public sealed class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.ToTable("ProductItems");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);
        builder.Property(p => p.SerialNumber);
        builder.Property(p => p.CreatedAt);
        builder.Property(p => p.UpdatedAt);
        

        // Relations
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
    
}