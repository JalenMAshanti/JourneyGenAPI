using IdentityServer3.Core.Services;
using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.Factories;
using JSMS.Persitence.Models.Login;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public LoginController(IConfiguration configuration, IUserService userService)
        {
            _LoginRepository = new LoginRepository(connectionFactory.GetConnection());
            _configuration = configuration;
            _userService = userService;
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
                string token = CreateToken(user);
                return Ok(token);
            }
        }

        private string CreateToken(Login_DTO login)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, login.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("JwtSettings:Key").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
