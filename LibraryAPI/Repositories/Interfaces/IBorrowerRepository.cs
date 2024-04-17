using LibraryAPI.Models;

namespace LibraryAPI.Repositories;

public interface IBorrowerRepository
{
    public Task<BorrowerEntity> Create(BorrowerEntity data);
    public Task<List<BorrowerEntity>> GetListAsync();
    public Task<BorrowerEntity?> GetByIdAsync(Guid id);
    public Task<BorrowerEntity?> UpdateByIdAsync(Guid id, BorrowerEntity data);
    public Task<BorrowerEntity?> SoftDeleteByIdAsync(Guid id);
}