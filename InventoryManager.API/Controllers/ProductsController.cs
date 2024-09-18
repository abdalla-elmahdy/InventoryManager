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

        var oResult = await _service.CreateAsync(dto);
        return Ok(new ProductDto(oResult));
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

}
