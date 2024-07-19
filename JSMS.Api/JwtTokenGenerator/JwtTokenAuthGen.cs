using JSMS.Persitence.DataTransferObjects;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JSMS.Api.JwtTokenGenerator
{
    public class JwtTokenAuthGen
    {
        private readonly IConfiguration _configuration;
        public JwtTokenAuthGen(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string CreateToken_Admin(Login_DTO login)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, login.Email),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User"),
            new Claim(ClaimTypes.Role, "Leader")
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

        public string CreateToken_Leader(Login_DTO login)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, login.Email),
            new Claim(ClaimTypes.Role, "User"),
            new Claim(ClaimTypes.Role, "Leader")
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

        public string CreateToken_User(Login_DTO login)
        {
            List<Claim> claims = new List<Claim> {
            new Claim(ClaimTypes.Name, login.Email),
            new Claim(ClaimTypes.Role, "User"),
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
