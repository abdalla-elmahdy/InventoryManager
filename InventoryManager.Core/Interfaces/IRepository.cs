namespace InventoryManager.Core.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}
