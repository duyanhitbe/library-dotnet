using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories.Implements;

public class UserRepository : IUserRepository
{
    private readonly LibraryDbContext _dbContext;

    public UserRepository(LibraryDbContext context)
    {
        _dbContext = context;
    }

    public async Task<UserEntity> Create(UserEntity data)
    {
        await _dbContext.Users.AddAsync(data);
        await _dbContext.SaveChangesAsync();
        return data;
    }

    public async Task<List<UserEntity>> GetListAsync()
    {
        return await _dbContext.Users
            .Where(e => e.DeletedAt == null)
            .ToListAsync();
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id && e.DeletedAt == null);
    }

    public async Task<UserEntity?> UpdateByIdAsync(Guid id, UserEntity data)
    {
        var user = await GetByIdAsync(id);

        if (user == null) return null;

        user.Username = data.Username;

        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<UserEntity?> SoftDeleteByIdAsync(Guid id)
    {
        var user = await GetByIdAsync(id);

        if (user == null) return null;

        user.DeletedAt = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return user;
    }
}