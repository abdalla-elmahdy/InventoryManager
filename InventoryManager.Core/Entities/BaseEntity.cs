using System.ComponentModel.DataAnnotations;
using InventoryManager.Core.Interfaces;

namespace InventoryManager.Core.Entities;

public class BaseEntity : ITrackable
{
    [Key]
    public Guid TrackingNumber { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}
