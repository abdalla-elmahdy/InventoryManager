using InventoryManager.Core.Interfaces;

namespace InventoryManager.Core.Entities;

public class BaseEntity : ITrackable
{
    public int Id { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
    public Guid TrackingNumber { get; set; }
}
