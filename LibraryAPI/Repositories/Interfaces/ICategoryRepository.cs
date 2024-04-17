using LibraryAPI.Models;

namespace LibraryAPI.Repositories;

public interface ICategoryRepository
{
    public Task<CategoryEntity> Create(CategoryEntity data);
    public Task<List<CategoryEntity>> GetListAsync();
    public Task<CategoryEntity?> GetByIdAsync(Guid id);
    public Task<CategoryEntity?> UpdateByIdAsync(Guid id, CategoryEntity data);
    public Task<CategoryEntity?> SoftDeleteByIdAsync(Guid id);
}