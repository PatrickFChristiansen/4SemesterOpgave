using Domain.Entities;

namespace Domain.Repositories
{
    public interface IInstitutionRepository
    {
        Task<Institution?> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<Institution>> GetAllAsync();

        Task AddAsync(Institution institution);

        Task UpdateAsync(Institution institution);

        Task DeleteAsync(Guid id);
    }
}