using Microsoft.AspNetCore.Mvc;
using TodoList.Auth;
using TodoList.Dtos;

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


        //quick and dirty login mock
        [HttpPost("login")]
        public IActionResult Login([FromBody] CredentialsDto loginCredentials)
        {
            if (loginCredentials is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = new UserDto
            {
                Id = 1,
                Email = "test@test.com"
            };

            var token = _tokenProvider.GenerateToken(user);

            return Ok(new AuthenticationDto { Token = token });
        }
    }
}
