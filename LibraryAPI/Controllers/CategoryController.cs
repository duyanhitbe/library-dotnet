using AutoMapper;
using LibraryAPI.DTO.Category;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[Route("/api/category")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var categories = await categoryRepository.GetListAsync();
        return Ok(categories);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto data)
    {
        var categoryData = mapper.Map<CategoryEntity>(data);
        var category = await categoryRepository.Create(categoryData);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateCategoryDto data)
    {
        var categoryData = mapper.Map<CategoryEntity>(data);
        var category = await categoryRepository.UpdateByIdAsync(id, categoryData);
        return Ok(category);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> SoftDeleteById([FromRoute] Guid id)
    {
        var category = await categoryRepository.SoftDeleteByIdAsync(id);
        return Ok(category);
    }
}