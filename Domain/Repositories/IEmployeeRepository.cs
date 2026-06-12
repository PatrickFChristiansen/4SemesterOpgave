using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id);

        Task<IReadOnlyCollection<Employee>> GetAllAsync();

        Task<IReadOnlyCollection<Employee>> GetByInstitutionIdAsync(Guid institutionId);

        Task AddAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(Guid id);
    }
}