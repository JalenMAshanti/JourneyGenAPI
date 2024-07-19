using JSMS.Persitence.Factories;
using JSMS.Persitence.Mappers;
using JSMS.Persitence.Models.Register;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        DbConnectionFactory connectionFactory = new DbConnectionFactory();
        private readonly RegisterRepository _registerRepository;

        public RegisterController()
        {
          _registerRepository = new RegisterRepository(connectionFactory.GetConnection());
        }

        [HttpPost("/RegisterUser")]
        public async Task RegisterUser(RegisterRequest request) => await _registerRepository.RegisterUserAsync(RegisterRequestMapper.RegisterMapper(request));
    }
}
