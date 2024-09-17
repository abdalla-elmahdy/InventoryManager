using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManager.Core.Entities;

public class OrderItem : BaseEntity
{
   public int Quantity { get; set; }
   public decimal TotalPrice { get; set; }

   public Guid ProductTrackingNumber { get; set; }
   [ForeignKey(nameof(ProductTrackingNumber))]
   public Product Product { get; set; } = new();

   public Guid OrderTrackingNumber { get; set; }
   [ForeignKey(nameof(OrderTrackingNumber))]
   public Order Order { get; set; } = new();
}
