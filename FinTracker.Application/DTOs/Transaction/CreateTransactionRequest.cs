namespace FinTracker.Application.DTOs.Transaction
{
    public class CreateTransactionRequest
    {
        public int AccountId { get; set; }

        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string? Description { get; set; }
    }
}
