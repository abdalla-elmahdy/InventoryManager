using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Products;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IService<ProductOperationsDto, Product> service) : ControllerBase
{
    private readonly IService<ProductOperationsDto, Product> _service = service;

    [HttpPost("")]
    public async Task<ActionResult<ProductDto>> CreateAsync([FromBody] ProductOperationsDto dto)
    {
        if (dto == null)
            return BadRequest();
        try
        {

            var oResult = await _service.CreateAsync(dto);
            return Ok(new ProductDto(oResult));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }

    }

    [HttpGet("")]
    public async Task<ActionResult<List<ProductDto>>> ReadAllAsync()
    {
        var products = await _service.ReadAllAsync();
        return Ok(products.Select(p => new ProductDto(p)));
    }

    [HttpGet("{trackingNumber}")]
    public async Task<ActionResult<ProductDto>> ReadAsync([FromRoute] Guid trackingNumber)
    {
        var product = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (product == null)
            return NotFound();
        return Ok(new ProductDto(product));
    }

    [HttpPut("{trackingNumber}")]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] Guid trackingNumber,
        [FromBody] ProductOperationsDto dto
    )
    {
        if (dto == null)
            return BadRequest();
        var product = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (product == null)
            return NotFound("product doesn't exist");

        try
        {
            await _service.UpdateAsync(product, dto);
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
        var product = await _service.ReadByTrackingNumberAsync(trackingNumber);
        if (product == null)
            return NotFound("product doesn't exist");

        await _service.DeleteAsync(product);
        return NoContent();
    }

}
