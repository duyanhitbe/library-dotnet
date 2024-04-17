using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implements;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryDbContext _dbContext;

    public CategoryRepository(LibraryDbContext context)
    {
        _dbContext = context;
    }

    public async Task<CategoryEntity> Create(CategoryEntity data)
    {
        await _dbContext.Categories.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<CategoryEntity>> GetListAsync()
    {
        return await _dbContext.Categories
            .Where(e => e.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<CategoryEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
    }

    public async Task<CategoryEntity?> UpdateByIdAsync(Guid id, CategoryEntity data)
    {
        var category = await GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }

        category.Name = data.Name;

        await _dbContext.SaveChangesAsync();

        return category;
    }

    public async Task<CategoryEntity?> SoftDeleteByIdAsync(Guid id)
    {
        var category = await GetByIdAsync(id);

        if (category == null)
        {
            return null;
        }

        category.DeletedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return category;
    }
}