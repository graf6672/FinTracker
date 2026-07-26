using FinTracker.Domain.Entities;

namespace FinTracker.Application.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId);

        Task<IEnumerable<Transaction>> GetByPeriodAsync(DateTime start, DateTime end);
    }
}
