using BC = BCrypt.Net.BCrypt;
using FinTracker.Application.Interfaces.Services;

namespace FinTracker.Infrastructure.Services
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return BC.HashPassword(password);
        }
        
        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
