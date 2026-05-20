using backend.Data;
using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(ApplicationDbContext context)
        {
            _authService = new AuthService(context);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (await _authService.Login(loginDTO))
            {
                return NoContent();

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            string username = await _authService.CreateUser(registerUserDTO);

            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest();
            }

            return Ok(username);
        }

        [HttpPost]
        [Route("email/{email}")]
        public async Task<IActionResult> CheckEmailDuplicate(string email)
        {
            if (await _authService.IsEmailDuplicate(email))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
