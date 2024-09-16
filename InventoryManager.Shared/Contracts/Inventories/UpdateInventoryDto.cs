namespace InventoryManager.Shared.Contracts.Inventories;

public record UpdateInventoryDto
{
    public required string Name { get; set; }
    public int Quantity { get; set; }
    public int RedorderLevel { get; set; }
    public required string Location { get; set; }
}
