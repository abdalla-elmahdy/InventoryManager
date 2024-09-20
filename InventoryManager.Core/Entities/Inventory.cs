namespace InventoryManager.Core.Entities;

public class Inventory: BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int RedorderLevel { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTimeOffset LastUpdated { get; set; }    
    
    public List<Product> Products { get; set; } = new();

}
