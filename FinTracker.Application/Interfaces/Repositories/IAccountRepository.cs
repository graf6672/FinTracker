using FinTracker.Domain.Entities;

namespace FinTracker.Application.Interfaces.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetByUserIdAsync(int userId);
    }
}
