namespace FinTracker.Application.DTOs.User
{
    public class RegisterUserRequest
    {
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
