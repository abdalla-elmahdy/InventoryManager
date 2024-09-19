using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Shared.Contracts.Orders;

public class OrderOperationsDto
{
    [Required]
    public required string Supplier { get; set; }
    [Required]
    public decimal TotalAmount { get; set; }
    [Required]
    public required string Status { get; set; }
    [Required]
    public required string OrderType { get; set; }
    [Required]
    public DateTimeOffset OrderDate { get; set; }
    [Required]
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
    [Required]
    public DateTimeOffset ReceivedDate { get; set; }
}
