using FinTracker.Domain.Entities;

namespace FinTracker.Application.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByUserIdAsync(int userId);
    }
}
