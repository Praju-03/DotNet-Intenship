using Job_Portal_Management_System.DTOs.Authentication;
using Job_Portal_Management_System.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Job_Portal_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(
            IAuthService authService)
        {
            this.authService = authService;
        }


        // REGISTER
        // POST: api/Auth/register


        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterDto dto)
        {
            try
            {
                var result =
                    await authService.RegisterAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // LOGIN
        // POST: api/Auth/login
      

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDto dto)
        {
            try
            {
                var result =
                    await authService.LoginAsync(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}