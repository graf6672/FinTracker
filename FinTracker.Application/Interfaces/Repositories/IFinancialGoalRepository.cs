using FinTracker.Domain.Entities;

namespace FinTracker.Application.Interfaces.Repositories
{
    public interface IFinancialGoalRepository : IRepository<FinancialGoal>
    {
        Task<IEnumerable<FinancialGoal>> GetByUserIdAsync(int userId);
    }
}
