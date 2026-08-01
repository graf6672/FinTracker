namespace FinTracker.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; private set; }

        public Account Account { get; private set; }
        public int AccountId { get; private set; }

        public Category Category { get; private set; }
        public int CategoryId { get; private set; }

        public decimal Amount { get; private set; }

        public string? Description { get; private set; }

        public DateTime TransactionDate { get; private set; }

        private Transaction()
        {
            // Requiered my EF Core
        }

        public Transaction(Account account, Category category, decimal amount, DateTime transDate, string? description = null)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            if (amount <= 0)
            {
                throw new ArgumentException("The transaction amount cannot be less than or equal to zero.", nameof(amount));
            }
            if (description?.Length > 500)
            {
                throw new ArgumentException("Desciption cannot exceed 500 characters", nameof(description));
            }
            Account = account;
            AccountId = account.Id;
            Category = category;
            CategoryId = category.Id;
            Amount = amount;
            TransactionDate = transDate;
            Description = description?.Trim();
        }
        public void ChangeAmount(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("New amount cannot be less or equal 0.", nameof(amount));
            }
            Amount = amount;
        }
        public void ChangeCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("New category not specified.", nameof(category));
            }
            Category = category;
            CategoryId = category.Id;
        }
        public void ChangeAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("New account not specified.", nameof(account));
            }
            Account = account;
            AccountId = account.Id;
        }
        public void ChangeDescription(string? description)
        {
            if (description?.Length > 500)
            {
                throw new ArgumentException("Description cannot exceed 500 characters.", nameof(description));
            }
            Description = description?.Trim();
        }
        public void ChangeTransactionDate(DateTime transactionDate)
        {
            TransactionDate = transactionDate;
        }
    }
}
