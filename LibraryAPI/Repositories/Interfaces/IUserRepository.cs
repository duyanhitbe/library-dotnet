using LibraryAPI.Models;

namespace LibraryAPI.Repositories;

public interface IUserRepository
{
    public Task<UserEntity> Create(UserEntity data);
    public Task<List<UserEntity>> GetListAsync();
    public Task<UserEntity?> GetByIdAsync(Guid id);
    public Task<UserEntity?> UpdateByIdAsync(Guid id, UserEntity data);
    public Task<UserEntity?> SoftDeleteByIdAsync(Guid id);
}