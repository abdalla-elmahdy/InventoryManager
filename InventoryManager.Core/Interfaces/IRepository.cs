namespace InventoryManager.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class, ITrackable
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity?> GetByTrackingNumberAsync(Guid trackingNumber);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
