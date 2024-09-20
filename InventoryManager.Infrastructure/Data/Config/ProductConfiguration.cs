using InventoryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManager.Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public ProductConfiguration()
    {
        
    }
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.TrackingNumber).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(50);
        builder.Property(p => p.Description).HasMaxLength(200);
    }
}
