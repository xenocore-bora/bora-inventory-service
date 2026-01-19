using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Infrastructure.Outbox;

public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.ToTable("OutboxMessages");
        
        builder.Property(o => o.Id).ValueGeneratedOnAdd();
        builder.Property(o => o.OccurredOn);
        builder.Property(o => o.Type);
        builder.Property(o => o.Payload);
        builder.Property(o => o.Processed);
    }
}