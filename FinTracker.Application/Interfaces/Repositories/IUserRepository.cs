using FinTracker.Domain.Entities;

namespace FinTracker.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<User?> GetByNicknameAsync(string nickname);
    }
}
