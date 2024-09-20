using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(IService<CategoryOperationsDto, Category> service)
: ControllerBase
{
    private readonly IService<CategoryOperationsDto, Category> _service = service;

    [HttpPost("")]
    public async Task<ActionResult<CategoryDto>> CreateAsync(
        [FromBody] CategoryOperationsDto dto
        )
    {
        if (dto == null)
            return BadRequest("Categories parameters weren't provided");

        var oResult = await _service.CreateAsync(dto);
        return Ok(new CategoryDto(oResult));
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> ReadAllAsync()
    {
        var categories = await _service.ReadAllAsync();
        return Ok(categories.Select(c => new CategoryDto(c)));
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<CategoryDto>> ReadAsync([FromRoute] Guid trackingNumber)
    {
        var category = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (category == null)
            return NotFound();

        return Ok(new CategoryDto(category));
    }

    [HttpPut("{trackingNumber}")]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid trackingNumber,
        [FromBody] CategoryOperationsDto dto
    )
    {
        if (dto == null)
            return BadRequest();

        var category = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (category == null)
            return NotFound();

        await _service.UpdateAsync(category, dto);
        return NoContent();
    }

    [HttpDelete("{trackingNumber}")]
    public async Task<ActionResult> DeleteAsync(Guid trackingNumber)
    {
        var category = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (category == null)
            return NotFound();

        await _service.DeleteAsync(category);
        return NoContent();
    }
}
