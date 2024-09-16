namespace InventoryManager.Shared.Contracts.Inventories;

public record CreateInventoryDto : UpdateInventoryDto
{
    public DateTimeOffset LastUpdated { get; set; }
}
