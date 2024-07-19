using IdentityServer3.Core.Services;
using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.Factories;
using JSMS.Persitence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DbConnectionFactory connectionFactory = new DbConnectionFactory();
        private readonly UserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(UserRepository userRepository, IUserService userService)
        {
            _userRepository = new UserRepository(connectionFactory.GetConnection());   
            _userService = userService;
        }


        [HttpGet("GetUserByID")]
        public async Task<User_DTO> GetUserById(int id) => await _userRepository.GetUserByIdAsync(id);


     
        [HttpDelete("DeleteUserById"), Authorize(Roles = "Admin")]
        public async Task DeleteUser(int id) => await _userRepository.DeleteUserAsync(id);      
    }
}
