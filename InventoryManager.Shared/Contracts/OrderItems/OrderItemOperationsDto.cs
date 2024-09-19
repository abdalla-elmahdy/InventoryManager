using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Shared.Contracts.OrderItems;

public record OrderItemOperationsDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
    [Required]
    public Guid Product { get; set; }
    [Required]
    public Guid Order { get; set; }
}
