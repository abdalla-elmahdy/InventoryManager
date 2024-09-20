using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Products;

namespace InventoryManager.Services;

public class ProductsService<TRequestDto, TEntity>(
    IRepository<Product> productRepository,
    IRepository<Category> categoryRepository,
    IRepository<Inventory> inventoryRepository
    )
: IService<TRequestDto, TEntity>
where TRequestDto : ProductOperationsDto
where TEntity : Product
{
    private readonly IRepository<Product> _productRepository = productRepository;
    private readonly IRepository<Category> _categoryRepository = categoryRepository;
    private readonly IRepository<Inventory> _inventoryRepository = inventoryRepository;

    public async Task<TEntity> CreateAsync(TRequestDto dto)
    {
        var category = await _categoryRepository.GetByTrackingNumberAsync(dto.Category) ??
            throw new NotFoundException("Category wasn't found");

        var inventory = await _inventoryRepository.GetByTrackingNumberAsync(dto.Inventory) ??
            throw new NotFoundException("Inventory wasn't found");

        var product = new Product
        {
            TrackingNumber = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now,
            Name = dto.Name,
            Description = dto.Description,
            Weight = dto.Weight,
            Width = dto.Width,
            Length = dto.Length,
            Height = dto.Height,
            UnitPrice = dto.UnitPrice,
            Tax = dto.Tax,
            ProductionCost = dto.ProductionCost,
            ProfitPerUnit = dto.ProfitPerUnit,
            CategoryTrackingNumber = dto.Category,
            Category = category,
            InventoryTrackingNumber = dto.Inventory,
            Inventory = inventory
        };

        var oResult = await _productRepository.CreateAsync(product);
        return (TEntity)product;
    }



    public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
        (IEnumerable<TEntity>)await _productRepository.GetAllAsync();

    public async Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber) =>
        (TEntity?)await _productRepository.GetByTrackingNumberAsync(trackingNumber);

    public async Task UpdateAsync(TEntity entity, TRequestDto dto)
    {
        var category = await _categoryRepository.GetByTrackingNumberAsync(dto.Category) ??
            throw new NotFoundException("Category wasn't found");

        var inventory = await _inventoryRepository.GetByTrackingNumberAsync(dto.Inventory) ??
            throw new NotFoundException("Inventory wasn't found");

        entity.ModifiedOn = DateTimeOffset.Now;
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Weight = dto.Weight;
        entity.Width = dto.Width;
        entity.Length = dto.Length;
        entity.Height = dto.Height;
        entity.UnitPrice = dto.UnitPrice;
        entity.Tax = dto.Tax;
        entity.ProductionCost = dto.ProductionCost;
        entity.ProfitPerUnit = dto.ProfitPerUnit;
        entity.CategoryTrackingNumber = dto.Category;
        entity.Category = category;
        entity.InventoryTrackingNumber = dto.Inventory;
        entity.Inventory = inventory;

        await _productRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(TEntity entity) =>
        await _productRepository.DeleteAsync(entity);

}
