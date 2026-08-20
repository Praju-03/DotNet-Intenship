namespace Job_Portal_Management_System.DTOs.Authentication
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}