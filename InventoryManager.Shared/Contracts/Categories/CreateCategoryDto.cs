using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Shared.Contracts.Categories;

public record CreateCategoryDto
{
    [Required(ErrorMessage = "Name field is required")]
    [MaxLength(50, ErrorMessage = "Name must be under 50 chars")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Description field is required")]
    [MaxLength(200, ErrorMessage = "Description must be under 200 chars")]
    public required string Description { get; set; }
}
