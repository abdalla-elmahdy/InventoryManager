using InventoryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManager.Infrastructure.Data.Config;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.Property(p => p.TrackingNumber).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Location).HasMaxLength(200);
    }
}
