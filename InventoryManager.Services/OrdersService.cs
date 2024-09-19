using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Orders;

namespace InventoryManager.Services;

public class OrdersService<TRequestDto, TEntity>(IRepository<Order> repository)
: IService<TRequestDto, TEntity>
where TEntity : Order
where TRequestDto : OrderOperationsDto
{
    private readonly IRepository<Order> _repository = repository;

    public async Task<TEntity> CreateAsync(TRequestDto dto)
    {
        var order = new Order
        {
            TrackingNumber = Guid.NewGuid(),
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now,
            Supplier = dto.Supplier,
            TotalAmount = dto.TotalAmount,
            Status = dto.Status,
            OrderType = dto.OrderType,
            OrderDate = dto.OrderDate,
            ExpectedDeliveryDate = dto.ExpectedDeliveryDate,
            ReceivedDate = dto.ReceivedDate
        };
        var oResult = await _repository.CreateAsync(order);
        return (TEntity)oResult;
    }

    public async Task<IEnumerable<TEntity>> ReadAllAsync() =>
        (IEnumerable<TEntity>)await _repository.GetAllAsync();

    public async Task<TEntity?> ReadByTrackingNumberAsync(Guid trackingNumber) =>
        (TEntity?)await _repository.GetByTrackingNumberAsync(trackingNumber);


    public async Task UpdateAsync(TEntity entity, TRequestDto dto)
    {
        entity.ModifiedOn = DateTimeOffset.Now;
        entity.Supplier = dto.Supplier;
        entity.TotalAmount = dto.TotalAmount;
        entity.Status = dto.Status;
        entity.OrderType = dto.OrderType;
        entity.OrderDate = dto.OrderDate;
        entity.ExpectedDeliveryDate = dto.ExpectedDeliveryDate;
        entity.ReceivedDate = dto.ReceivedDate;

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity) =>
        await _repository.DeleteAsync(entity);
}