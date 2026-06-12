using Domain.Entities;

namespace Domain.Repositories
{
    public interface IChildRepository
    {
        Task<Child?> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<Child>> GetAllAsync();

        Task AddAsync(Child child);

        Task UpdateAsync(Child child);

        Task DeleteAsync(Guid id);
    }
}