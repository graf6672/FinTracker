using FinTracker.Domain.Enums;

namespace FinTracker.Domain.Entities
{
    public class FinancialGoal
    {
        public int Id { get; private set; }

        public User User { get; private set; }
        public int UserId { get; private set; }

        public string Name { get; private set; }

        public decimal TargetAmount { get; private set; }

        public decimal CurrentAmount { get; private set; }

        public DateTime? TargetDate { get; private set; }

        public GoalStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private FinancialGoal()
        {
            // Requiered my EF Core
        }

        public FinancialGoal(User user, string name, decimal targetAmount, decimal currentAmount = 0, DateTime? targetDate = null)
        {
            ArgumentNullException.ThrowIfNull(user);
            ArgumentNullException.ThrowIfNullOrWhiteSpace(name);
            if (targetAmount <= 0)
            {
                throw new ArgumentException("Target amount cannot be less than or equal to zero", nameof(targetAmount));
            }
            if (currentAmount < 0)
            {
                throw new ArgumentException("Current amount cannot be less than zero", nameof(currentAmount));
            }
            User = user;
            UserId = user.Id;
            Name = name.Trim();
            TargetAmount = targetAmount;
            CurrentAmount = currentAmount;
            TargetDate = targetDate;
            Status = GoalStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public void Rename(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            Name = name.Trim();
        }

        public void ChangeTargetAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("New target amount cannot be less than or equal to zero", nameof(amount));
            }
            TargetAmount = amount;
        }
        public void ChangeTargetDate(DateTime? targetDate)
        {
            TargetDate = targetDate;
        }
        public void Complete()
        {
            if (Status == GoalStatus.Completed)
            {
                throw new InvalidOperationException("Financial goal is already completed.");
            }
            Status = GoalStatus.Completed;
        }
        public void Reopen()
        {
            if (Status == GoalStatus.Active)
            {
                throw new InvalidOperationException("Financial goal is already active.");
            }
            Status = GoalStatus.Active;
        }
        public void IncreaseCurrentAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be less than or equal to zero.", nameof(amount));
            }
            CurrentAmount += amount;
        }
        public void DecreaseCurrentAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount cannot be less than or equal to zero.", nameof(amount));
            }
            if (CurrentAmount - amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Current amount cannot be less than zero.");
            }
            CurrentAmount -= amount;
        }
    }
}
