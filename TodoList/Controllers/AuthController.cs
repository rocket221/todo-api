using Microsoft.AspNetCore.Mvc;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtProvider _tokenProvider;

        public AuthController(IJwtProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginCredentials loginCredentials)
        {
            if (loginCredentials is null)
            {
                return BadRequest("Invalid client request");
            }

            //var user = _userService.GetUserByUsername(loginCredentials.Username);

            var user = new UserViewModel
            {
                Id = Guid.NewGuid(),
                Email = "test@test.com"
            };

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var token = _tokenProvider.GenerateToken(user);

            return Ok(new AuthenticationViewModel { Token = token });
        }
    }
}
