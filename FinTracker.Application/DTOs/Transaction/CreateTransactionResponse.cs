namespace FinTracker.Application.DTOs.Transaction
{
    public class CreateTransactionResponse
    {
        public int TransactionId { get; set; }

        public decimal NewBalance { get; set; }

    }
}
