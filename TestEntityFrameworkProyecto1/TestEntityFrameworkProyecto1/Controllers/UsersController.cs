using Microsoft.AspNetCore.Mvc;
using TestEntityFrameworkProyecto1.Context;
using TestEntityFrameworkProyecto1.Models;
using TestEntityFrameworkProyecto1.Service;

namespace TestEntityFrameworkProyecto1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ApplicationDbContext _context;

        public UsersController(IAuthService authService, ApplicationDbContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDto registerDto)
        {
            try
            {
                var user = await _authService.RegisterUser(
                    registerDto.Username,
                    registerDto.Email,
                    registerDto.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto loginDto)
        {
            try
            {
                var token = await _authService.Login(loginDto.Email, loginDto.Password);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
