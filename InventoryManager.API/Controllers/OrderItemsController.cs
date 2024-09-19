using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.OrderItems;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/orders/items")]
public class OrderItemsController(IService<OrderItemOperationsDto, OrderItem> service)
: ControllerBase
{
    private readonly IService<OrderItemOperationsDto, OrderItem> _service = service;

    [HttpPost("")]
    public async Task<ActionResult<OrderItemDto>> CreateAsync([FromBody] OrderItemOperationsDto dto)
    {
        if (dto == null)
            return BadRequest();
        try
        {

            var oResult = await _service.CreateAsync(dto);
            return Ok(new OrderItemDto(oResult));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpGet("")]
    public async Task<ActionResult<List<OrderItemDto>>> ReadAllAsync()
    {
        var items = await _service.ReadAllAsync();
        return Ok(items.Select(i => new OrderItemDto(i)));
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<OrderItemDto>> ReadAsync([FromRoute] Guid trackingNumber)
    {
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound();
        return Ok(new OrderItemDto(order));
    }

    [HttpPut("{trackingNumber}")]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid trackingNumber,
        [FromBody] OrderItemOperationsDto dto
    )
    {
        if (dto == null)
            return BadRequest();
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound("order doesn't exist");

        try
        {
            await _service.UpdateAsync(order, dto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{trackingNumber}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid trackingNumber)
    {
        var order = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (order == null)
            return NotFound("order doesn't exist");

        await _service.DeleteAsync(order);
        return NoContent();
    }
}
