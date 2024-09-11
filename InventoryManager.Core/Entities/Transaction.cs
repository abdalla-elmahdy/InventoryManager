namespace InventoryManager.Core.Entities;

public class Transaction: BaseEntity
{
    public DateTimeOffset TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
}
