using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserAccountRepository
    {
        Task<UserAccount?> GetByIdAsync(Guid id);

        Task<UserAccount?> GetByPersonIdAsync(Guid personId);

        Task AddAsync(UserAccount userAccount);

        Task UpdateAsync(UserAccount userAccount);
    }
}