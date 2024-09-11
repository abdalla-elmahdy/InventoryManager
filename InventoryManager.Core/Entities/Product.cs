namespace InventoryManager.Core.Entities;

public class Product : BaseEntity
{
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
    
    public int CategoryId { get; set; }
    public Category Category { get; set; } = new();

    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; } = new();

    public List<OrderItem> OrderItems { get; set; } =  new();
}
