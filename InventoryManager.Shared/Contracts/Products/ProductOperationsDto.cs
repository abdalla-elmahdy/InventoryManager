using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Shared.Contracts.Products;

public record ProductOperationsDto
{
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Description { get; set; }
    [Required]
    public float Weight { get; set; }
    [Required]
    public float Length { get; set; }
    [Required]
    public float Width { get; set; }
    [Required]
    public float Height { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
    [Required]
    public decimal Tax { get; set; }
    [Required]
    public decimal ProfitPerUnit { get; set; }
    [Required]
    public decimal ProductionCost { get; set; }
    [Required]
    public Guid Category { get; set; }
    [Required]
    public Guid Inventory { get; set; }
}
