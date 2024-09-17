using InventoryManager.Core.Entities;

namespace InventoryManager.Shared.Contracts.Inventories;

public class InventoryDto
{
    public Guid TrackingNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int RedorderLevel { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTimeOffset LastUpdated { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }

    public InventoryDto(Inventory inventory)
    {
        TrackingNumber = inventory.TrackingNumber;
        Name = inventory.Name;
        Quantity = inventory.Quantity;
        RedorderLevel = inventory.RedorderLevel;
        Location = inventory.Location;
        LastUpdated = inventory.LastUpdated;
        CreatedOn = inventory.CreatedOn;
        ModifiedOn = inventory.ModifiedOn;
    }
}
