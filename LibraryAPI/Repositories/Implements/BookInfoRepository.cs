using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implements;

public class BookInfoRepository : IBookInfoRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookInfoRepository(LibraryDbContext context)
    {
        _dbContext = context;
    }

    public async Task<BookInfoEntity> Create(BookInfoEntity data)
    {
        await _dbContext.BookInfos.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<BookInfoEntity>> GetListAsync()
    {
        return await _dbContext.BookInfos
            .Where(e => e.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<BookInfoEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.BookInfos.FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
    }

    public async Task<BookInfoEntity?> UpdateByIdAsync(Guid id, BookInfoEntity data)
    {
        var bookInfo = await GetByIdAsync(id);

        if (bookInfo == null) return null;

        bookInfo.Name = data.Name;
        bookInfo.Author = data.Author;
        bookInfo.PublicationDate = data.PublicationDate;

        await _dbContext.SaveChangesAsync();

        return bookInfo;
    }

    public async Task<BookInfoEntity?> SoftDeleteByIdAsync(Guid id)
    {
        var bookInfo = await GetByIdAsync(id);

        if (bookInfo == null) return null;

        bookInfo.DeletedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return bookInfo;
    }
}