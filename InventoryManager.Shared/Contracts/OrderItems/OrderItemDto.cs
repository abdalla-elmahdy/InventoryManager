using InventoryManager.Core.Entities;

namespace InventoryManager.Shared.Contracts.OrderItems;

public class OrderItemDto
{
    public Guid TrackingNumber { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid Product { get; set; }
    public Guid Order { get; set; }

    public OrderItemDto(OrderItem item)
    {
        TrackingNumber = item.TrackingNumber;
        CreatedOn = item.CreatedOn;
        ModifiedOn = item.ModifiedOn;
        Quantity = item.Quantity;
        TotalPrice = item.TotalPrice;
        Product = item.ProductTrackingNumber;
        Order = item.OrderTrackingNumber;
    }
}
