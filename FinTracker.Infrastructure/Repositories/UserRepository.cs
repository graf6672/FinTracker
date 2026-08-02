using FinTracker.Application.Interfaces.Repositories;
using FinTracker.Domain.Entities;
using FinTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FinTracker.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinTrackerDbContext _context;

        public UserRepository(FinTrackerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Users.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Users.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            return await _context.Users.FindAsync(userId);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(email);

            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByNicknameAsync(string nickname)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nickname);

            return await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }


    }
}
