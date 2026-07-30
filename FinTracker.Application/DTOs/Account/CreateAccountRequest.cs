namespace FinTracker.Application.DTOs.Account
{
    public class CreateAccountRequest
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
