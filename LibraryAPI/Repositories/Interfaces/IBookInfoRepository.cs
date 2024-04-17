using LibraryAPI.Models;

namespace LibraryAPI.Repositories;

public interface IBookInfoRepository
{
    public Task<BookInfoEntity> Create(BookInfoEntity data);
    public Task<List<BookInfoEntity>> GetListAsync();
    public Task<BookInfoEntity?> GetByIdAsync(Guid id);
    public Task<BookInfoEntity?> UpdateByIdAsync(Guid id, BookInfoEntity data);
    public Task<BookInfoEntity?> SoftDeleteByIdAsync(Guid id);
}