using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.API.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController(IService<CreateCategoryDto, Category> service)
: ControllerBase
{
    private readonly IService<CreateCategoryDto, Category> _service = service;

    [HttpPost("create")]
    public async Task<ActionResult<CategoryDto>> CreateAsync(
        [FromBody] CreateCategoryDto dto
        )
    {
        if (dto == null)
            return BadRequest("Categories parameters weren't provided");

        var oResult = await _service.CreateAsync(dto);
        return Ok(new CategoryDto(oResult));
    }
}
