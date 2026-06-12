using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<Room?> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<Room>> GetAllAsync();

        Task<IReadOnlyCollection<Room>> GetByInstitutionIdAsync(Guid institutionId);

        Task AddAsync(Room room);

        Task UpdateAsync(Room room);

        Task DeleteAsync(Guid id);
    }
}