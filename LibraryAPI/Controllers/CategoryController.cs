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
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var categories = await _categoryRepository.GetListAsync();
        return Ok(categories);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto data)
    {
        var categoryData = _mapper.Map<CategoryEntity>(data);
        var category = await _categoryRepository.Create(categoryData);
        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> UpdateById([FromRoute] Guid id, [FromBody] UpdateCategoryDto data)
    {
        var categoryData = _mapper.Map<CategoryEntity>(data);
        var category = await _categoryRepository.UpdateByIdAsync(id, categoryData);
        return Ok(category);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> SoftDeleteById([FromRoute] Guid id)
    {
        var category = await _categoryRepository.SoftDeleteByIdAsync(id);
        return Ok(category);
    }
}