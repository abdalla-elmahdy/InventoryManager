using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;

namespace InventoryManager.Services;

public class CategoriesService<TRequestDto, TEntity>(IRepository<Category> repository)
: IService<TRequestDto, TEntity>
  where TEntity : Category
  where TRequestDto : CategoryOperationsDto
{
    private readonly IRepository<Category> _repository = repository;
    public async Task<TEntity> CreateAsync(TRequestDto requestDto)
    {
        var category = new Category
        {
            Name = requestDto.Name,
            Description = requestDto.Description,
            TrackingNumber = Guid.NewGuid(),
            ModifiedOn = DateTimeOffset.Now,
            CreatedOn = DateTimeOffset.Now
        };

        var oResult = await _repository.CreateAsync(category);
        return (TEntity)oResult;
    }


    public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
        (IEnumerable<TEntity>)await _repository.GetAllAsync();

    public async Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber) =>
        (TEntity?)await _repository.GetByTrackingNumberAsync(trackingNumber);

    public async Task UpdateAsync(TEntity entity, TRequestDto requestDto)
    {
        entity.Name = requestDto.Name;
        entity.Description = requestDto.Description;
        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity) =>
        await _repository.DeleteAsync(entity);
}
