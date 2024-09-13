namespace InventoryManager.Core.Interfaces;

public interface IService<TRequestDto, TEntity>
{
    Task<TEntity> CreateAsync(TRequestDto requestDto);
    Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber);
    Task<IEnumerable<TEntity>> ReadAllAsync();
    Task UpdateAsync(TEntity entity, TRequestDto requestDto);
    Task DeleteAsync(Guid trackingNumber);
}
