using InventoryManager.Core.Entities;

namespace InventoryManager.Shared.Contracts.Orders;

public class OrderDto
{
    public Guid TrackingNumber { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public string OrderType { get; set; } = string.Empty;
    public DateTimeOffset OrderDate { get; set; }
    public DateTimeOffset ExpectedDeliveryDate { get; set; }
    public DateTimeOffset ReceivedDate { get; set; }

    public OrderDto(Order order)
    {
        TrackingNumber = order.TrackingNumber;
        CreatedOn = order.CreatedOn;
        ModifiedOn = order.ModifiedOn;
        Supplier = order.Supplier;
        TotalAmount = order.TotalAmount;
        Status = order.Status;
        OrderType = order.OrderType;
        OrderDate = order.OrderDate;
        ExpectedDeliveryDate = order.ExpectedDeliveryDate;
        ReceivedDate = order.ReceivedDate;
    }
}
