using InventoryManager.Core.Entities;

namespace InventoryManager.Shared.Contracts.Products;

public class ProductDto
{
    public Guid TrackingNumber { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Weight { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal ProfitPerUnit { get; set; }
    public decimal ProductionCost { get; set; }
    public Guid Category { get; set; }
    public Guid Inventory { get; set; }

    public ProductDto(Product product)
    {
        TrackingNumber = product.TrackingNumber;
        CreatedOn = product.CreatedOn;
        ModifiedOn = product.ModifiedOn;
        Name = product.Name;
        Description = product.Description;
        Weight = product.Weight;
        Length = product.Length;
        Width = product.Width;
        Height = product.Height;
        UnitPrice = product.UnitPrice;
        Tax = product.Tax;
        ProfitPerUnit = product.ProfitPerUnit;
        ProductionCost = product.ProductionCost;
        Category = product.CategoryTrackingNumber;
        Inventory = product.InventoryTrackingNumber;
    }
}
