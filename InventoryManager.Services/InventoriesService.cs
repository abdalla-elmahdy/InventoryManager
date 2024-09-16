using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Inventories;

namespace InventoryManager.Services;

public class InventoriesService<TRequestDto, TEntity>(IRepository<Inventory> repository)
: IService<TRequestDto, TEntity>
where TRequestDto : InventoryOperationsDto
where TEntity : Inventory
{
    private readonly IRepository<Inventory> _repository = repository;
    public async Task<TEntity> CreateAsync(TRequestDto requestDto)
    {
        var inventory = new Inventory
        {
            TrackingNumber = Guid.NewGuid(),
            Name = requestDto.Name,
            Quantity = requestDto.Quantity,
            RedorderLevel = requestDto.RedorderLevel,
            Location = requestDto.Location,
            LastUpdated = requestDto.LastUpdated,
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now
        };
        var oResult = await _repository.CreateAsync(inventory);
        return (TEntity)oResult;
    }


    public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
        (IEnumerable<TEntity>)await _repository.GetAllAsync();

    public async Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber) =>
        (TEntity?)await _repository.GetByTrackingNumberAsync(trackingNumber);

    public async Task UpdateAsync(TEntity entity, TRequestDto requestDto)
    {
        entity.Name = requestDto.Name;
        entity.Quantity = requestDto.Quantity;
        entity.RedorderLevel = requestDto.RedorderLevel;
        entity.Location = requestDto.Location;
        entity.LastUpdated = DateTimeOffset.Now;
        entity.ModifiedOn = DateTimeOffset.Now;

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity) =>
        await _repository.DeleteAsync(entity);
}
