using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Shared.Contracts.Inventories;

public record InventoryOperationsDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int RedorderLevel { get; set; }
    [Required]
    [MaxLength(100)]
    public required string Location { get; set; }
    public DateTimeOffset LastUpdated { get; set; } = DateTimeOffset.Now;
}
