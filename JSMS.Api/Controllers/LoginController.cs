using IdentityServer3.Core.Services;
using JSMS.Api.JwtTokenGenerator;
using JSMS.Persitence.Factories;
using JSMS.Persitence.Models.Login;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {

        private readonly DbConnectionFactory connectionFactory = new DbConnectionFactory();
        private readonly IConfiguration _configuration;
        private readonly LoginRepository _LoginRepository;
        private readonly IUserService _userService;
        private readonly JwtTokenAuthGen _jwtAuthGen;

        public LoginController(IConfiguration configuration, IUserService userService, JwtTokenAuthGen jwtTokenAuthGen)
        {
            _LoginRepository = new LoginRepository(connectionFactory.GetConnection());
            _configuration = configuration;
            _userService = userService;
            _jwtAuthGen = jwtTokenAuthGen;
        }


        [HttpGet("UserLogin")]
        public async Task<IActionResult> UserLogin(string email, string password)
        {

            var request = new LoginRequest(email, password);

            var user = await _LoginRepository.LoginUserAsync(request);

            if (user.Password is null || user.Email is null)
            {
                return NotFound("Incorrect Username or Password, Please try again.");
            }
            else
            {
                string token;

                if (user.RoleId == 0)
                {
                    token = _jwtAuthGen.CreateToken_User(user);
                }
                else if (user.RoleId == 1)
                {
                    token = _jwtAuthGen.CreateToken_Leader(user);
                }
                else if (user.RoleId == 2)
                {
                    token = _jwtAuthGen.CreateToken_Admin(user);
                }
                else
                {
                    token = null;
                }
                return Ok(token);
            }
        }
    }
}
