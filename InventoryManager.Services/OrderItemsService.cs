using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.OrderItems;

namespace InventoryManager.Services;

public class OrderItemsService<TRequestDto, TEntity>(
    IRepository<OrderItem> itemsRepository,
    IRepository<Order> ordersRepository,
    IRepository<Product> productsRepository
) : IService<TRequestDto, TEntity>
where TRequestDto : OrderItemOperationsDto
where TEntity : OrderItem
{
    private readonly IRepository<OrderItem> _itemsRepository = itemsRepository;
    private readonly IRepository<Order> _ordersRepository = ordersRepository;
    private readonly IRepository<Product> _productsRepository = productsRepository;

    public async Task<TEntity> CreateAsync(TRequestDto dto)
    {
        var order = await _ordersRepository.GetByTrackingNumberAsync(dto.Order) ??
            throw new NotFoundException("Order doesn't exist");
        var product = await _productsRepository.GetByTrackingNumberAsync(dto.Product) ??
            throw new NotFoundException("Product doesn't exist");

        var item = new OrderItem
        {
            TrackingNumber = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now,
            Quantity = dto.Quantity,
            TotalPrice = dto.TotalPrice,
            OrderTrackingNumber = dto.Order,
            Order = order,
            ProductTrackingNumber = dto.Product,
            Product = product
        };

        var oResult = await _itemsRepository.CreateAsync(item);
        return (TEntity)oResult;
    }

    public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
        (IEnumerable<TEntity>)await _itemsRepository.GetAllAsync();


    public async Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber) =>
        (TEntity?)await _itemsRepository.GetByTrackingNumberAsync(trackingNumber);

    public async Task UpdateAsync(TEntity entity, TRequestDto dto)
    {
        var order = await _ordersRepository.GetByTrackingNumberAsync(dto.Order) ??
            throw new NotFoundException("Order doesn't exist");
        var product = await _productsRepository.GetByTrackingNumberAsync(dto.Product) ??
            throw new NotFoundException("Product doesn't exist");

        entity.ModifiedOn = DateTimeOffset.Now;
        entity.Quantity = dto.Quantity;
        entity.TotalPrice = dto.TotalPrice;
        entity.OrderTrackingNumber = dto.Order;
        entity.Order = order;
        entity.ProductTrackingNumber = dto.Product;
        entity.Product = product;

        await _itemsRepository.UpdateAsync(entity);
    }
    public async Task DeleteAsync(TEntity entity) =>
        await _itemsRepository.DeleteAsync(entity);

}