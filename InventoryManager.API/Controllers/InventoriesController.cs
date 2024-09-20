using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/inventories")]
public class InventoriesController(IService<InventoryOperationsDto, Inventory> service)
: ControllerBase
{
    private readonly IService<InventoryOperationsDto, Inventory> _service = service;

    [HttpPost("")]
    public async Task<ActionResult<InventoryDto>> CreateAsync([FromBody] InventoryOperationsDto dto)
    {
        if (dto == null)
            return BadRequest();

        var oResult = await _service.CreateAsync(dto);
        return Ok(new InventoryDto(oResult));
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<InventoryDto>>> ReadAllAsync()
    {
        var inventories = await _service.ReadAllAsync();
        return Ok(inventories.Select(i => new InventoryDto(i)));
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<InventoryDto>> ReadAsync([FromRoute] Guid trackingNumber)
    {
        var inventory = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (inventory == null)
            return NotFound();
        return Ok(new InventoryDto(inventory));
    }

    [HttpPut("{trackingNumber}")]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid trackingNumber,
        InventoryOperationsDto dto
    )
    {
        if (dto == null)
            return BadRequest();

        var inventory = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (inventory == null)
            return NotFound();

        await _service.UpdateAsync(inventory, dto);
        return NoContent();
    }

    [HttpDelete("{trackingNumber}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] Guid trackingNumber)
    {
        var inventory = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (inventory == null)
            return NotFound();

        await _service.DeleteAsync(inventory);
        return NoContent();
    }
}
