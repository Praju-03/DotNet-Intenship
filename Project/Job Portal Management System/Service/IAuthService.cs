using Job_Portal_Management_System.DTOs.Authentication;

namespace Job_Portal_Management_System.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(
            RegisterDto dto);

        Task<AuthResponseDto> LoginAsync(
            LoginDto dto);
    }
}