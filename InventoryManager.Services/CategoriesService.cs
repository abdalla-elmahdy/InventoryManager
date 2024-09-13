using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;

namespace InventoryManager.Services;

public class CategoriesService<TRequestDto, TEntity>(IRepository<Category> repository)
: IService<TRequestDto, TEntity>
  where TEntity : Category
  where TRequestDto : CreateCategoryDto
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

    public Task UpdateAsync(Guid trackingNumber, TRequestDto requestDto)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync(Guid trackingNumber)
    {
        throw new NotImplementedException();
    }
}
