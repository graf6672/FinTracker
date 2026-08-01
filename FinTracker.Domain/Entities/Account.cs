using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Entities
{
    public class Account
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }

        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public AccountStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

        private Account()
        {
            // Requiered my EF Core
        }

        public Account(User user, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.");
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            Name = name;
            User = user;
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
            Status = AccountStatus.Active;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("New name cannot be empty.");
            }
            if (name == Name)
            {
                throw new ArgumentException("New name cannot be same as old name.");
            }

            Name = name;
        }
        public void Close()
        {
            if (Status == AccountStatus.Closed)
            {
                throw new ArgumentException("The account is already closed");
            }

            Status = AccountStatus.Closed;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            Balance -= amount;
        }
    }
}
