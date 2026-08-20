using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Job_Portal_Management_System.DTOs.Authentication;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Services.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Job_Portal_Management_System.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        // ==============================
        // REGISTER
        // ==============================

        public async Task<AuthResponseDto> RegisterAsync(
            RegisterDto dto)
        {
            var existingUser =
                await userManager.FindByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new Exception(
                    "User with this email already exists.");
            }

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName,
                Role = dto.Role
            };

            var result =
                await userManager.CreateAsync(
                    user,
                    dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(
                        e => e.Description));

                throw new Exception(errors);
            }

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email!,
                FullName = user.FullName,
                Role = user.Role
            };
        }


        // ==============================
        // LOGIN
        // ==============================

        public async Task<AuthResponseDto> LoginAsync(
            LoginDto dto)
        {
            var user =
                await userManager.FindByEmailAsync(
                    dto.Email);

            if (user == null)
            {
                throw new Exception(
                    "Invalid email or password.");
            }

            var passwordValid =
                await userManager.CheckPasswordAsync(
                    user,
                    dto.Password);

            if (!passwordValid)
            {
                throw new Exception(
                    "Invalid email or password.");
            }

            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email!,
                FullName = user.FullName,
                Role = user.Role
            };
        }


        // ==============================
        // GENERATE JWT TOKEN
        // ==============================

        private string GenerateToken(
            ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id),

                new Claim(
                    ClaimTypes.Email,
                    user.Email ?? string.Empty),

                new Claim(
                    ClaimTypes.Name,
                    user.FullName),

                new Claim(
                    ClaimTypes.Role,
                    user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration["Jwt:Key"]!
                )
            );

            var credentials =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:
                    configuration["Jwt:Issuer"],

                audience:
                    configuration["Jwt:Audience"],

                claims: claims,

                expires:
                    DateTime.UtcNow.AddHours(2),

                signingCredentials:
                    credentials
            );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}