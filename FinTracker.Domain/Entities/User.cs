namespace FinTracker.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }

        public string Nickname { get; private set; }
        public string Email { get; private set; }
        private string PasswordHash { get;  set; }

        public DateTime CreatedAt { get; private set; }

        public ICollection<Account> Accounts { get; private set; } = new List<Account>();
        public ICollection<Category> Categories { get; private set; } = new List<Category>();
        public ICollection<FinancialGoal> FinancialGoals { get; private set; } = new List<FinancialGoal>();

        private User()
        {
            // Requiered my EF Core
        }
        public User(string nickname, string passwordHash, string email)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new ArgumentException("Nickname cannot be empty.", nameof(nickname));
            }
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            }

            Nickname = nickname;
            PasswordHash = passwordHash;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        public void ChangeNickname(string newNickname)
        {
            if (string.IsNullOrWhiteSpace(newNickname))
            {
                throw new ArgumentException("New nickname cannot be empty.", nameof(newNickname));
            }
            if (Nickname == newNickname)
            {
                throw new ArgumentException("New nickname cannot be same as old nickname.", nameof(newNickname));
            }

            Nickname = newNickname;
        }
    }
}
