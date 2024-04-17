using LibraryAPI.Models;

namespace LibraryAPI.Repositories;

public interface IBookRepository
{
    public Task<BookEntity> Create(BookEntity data);
    public Task<List<BookEntity>> GetListAsync();
    public Task<BookEntity?> GetByIdAsync(Guid id);
    public Task<BookEntity?> UpdateByIdAsync(Guid id, BookEntity data);
    public Task<BookEntity?> SoftDeleteByIdAsync(Guid id);
}