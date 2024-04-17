using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implements;

public class BorrowerRepository : IBorrowerRepository
{
    private readonly LibraryDbContext _dbContext;

    public BorrowerRepository(LibraryDbContext context)
    {
        _dbContext = context;
    }

    public async Task<BorrowerEntity> Create(BorrowerEntity data)
    {
        await _dbContext.Borrowers.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<BorrowerEntity>> GetListAsync()
    {
        return await _dbContext.Borrowers
            .Where(e => e.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<BorrowerEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Borrowers.FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
    }

    public async Task<BorrowerEntity?> UpdateByIdAsync(Guid id, BorrowerEntity data)
    {
        var borrower = await GetByIdAsync(id);

        if (borrower == null) return null;

        borrower.Name = data.Name;
        borrower.Phone = data.Phone;
        borrower.Address = data.Address;

        await _dbContext.SaveChangesAsync();

        return borrower;
    }

    public async Task<BorrowerEntity?> SoftDeleteByIdAsync(Guid id)
    {
        var borrower = await GetByIdAsync(id);

        if (borrower == null) return null;

        borrower.DeletedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return borrower;
    }
}