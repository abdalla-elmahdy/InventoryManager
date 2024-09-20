namespace InventoryManager.Core.Entities;

public class Order : BaseEntity
{
    public string Supplier { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string OrderType { get; set; } = string.Empty;
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
    public DateTimeOffset ReceivedDate { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();
}
