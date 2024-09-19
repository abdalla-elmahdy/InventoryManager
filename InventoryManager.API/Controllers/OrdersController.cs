using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Orders;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController(IService<OrderOperationsDto, Order> service)
: ControllerBase
{
    private readonly IService<OrderOperationsDto, Order> _service = service;

    [HttpPost("")]
    public async Task<ActionResult<OrderDto>> CreateAsync(OrderOperationsDto dto)
    {
        if (dto == null)
            return BadRequest();
        var oResult = await _service.CreateAsync(dto);
        return Ok(new OrderDto(oResult));
    }

    [HttpGet("")]
    public async Task<ActionResult<List<OrderDto>>> ReadAllAsync()
    {
        var orders = await _service.ReadAllAsync();
        return Ok(orders.Select(o => new OrderDto(o)));
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<OrderDto>> ReadAsync([FromRoute] Guid trackingNumber)
    {
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound("Order doesn't exist");

        return Ok(new OrderDto(order));
    }

    [HttpPut("{trackingNumber}")]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid trackingNumber,
        [FromBody] OrderOperationsDto dto
    )
    {
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound("Order doesn't exist");

        await _service.UpdateAsync(order, dto);
        return NoContent();
    }

    [HttpDelete("{trackingNumber}")]
    public async Task<ActionResult<OrderDto>> DeleteAsync([FromRoute] Guid trackingNumber)
    {
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound("Order doesn't exist");

        await _service.DeleteAsync(order);
        return NoContent();
    }
}
