using Domain.Entities;

namespace Domain.Repositories
{
    public interface IGuardianRepository
    {
        Task<Guardian?> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<Guardian>> GetAllAsync();

        Task AddAsync(Guardian guardian);

        Task UpdateAsync(Guardian guardian);

        Task DeleteAsync(Guid id);
    }
}