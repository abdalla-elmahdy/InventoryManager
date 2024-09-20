using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManager.Core.Entities;

namespace InventoryManager.Shared.Contracts.Categories;

public class CategoryDto
{
    public Guid TrackingNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }

    public CategoryDto(Category category)
    {
        TrackingNumber = category.TrackingNumber;
        Name = category.Name;
        Description = category.Description;
        CreatedOn = category.CreatedOn;
        ModifiedOn = category.ModifiedOn;
    }
}
