namespace FinTracker.Application.DTOs.FinancialGoal
{
    public class CreateFinancialGoalRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal TargetAmount { get; set; }
        public DateTime? TargetDate { get; set; }
    }
}
