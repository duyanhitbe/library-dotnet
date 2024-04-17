using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implements;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(LibraryDbContext context)
    {
        _dbContext = context;
    }

    public async Task<BookEntity> Create(BookEntity data)
    {
        await _dbContext.Books.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<BookEntity>> GetListAsync()
    {
        return await _dbContext.Books
            .Where(e => e.DeletedAt == null)
            .Include(e => e.BookInfo)
            .Include(e => e.Category)
            .ToListAsync();
    }

    public async Task<BookEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Books
            .Include(e => e.BookInfo)
            .Include(e => e.Category)
            .FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
    }

    public async Task<BookEntity?> UpdateByIdAsync(Guid id, BookEntity data)
    {
        var book = await GetByIdAsync(id);

        if (book == null) return null;

        book.CategoryId = data.CategoryId;
        book.BookInfoId = data.BookInfoId;

        await _dbContext.SaveChangesAsync();

        return book;
    }

    public async Task<BookEntity?> SoftDeleteByIdAsync(Guid id)
    {
        var book = await GetByIdAsync(id);

        if (book == null) return null;

        book.DeletedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return book;
    }
}