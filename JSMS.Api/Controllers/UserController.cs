﻿using IdentityServer3.Core.Services;
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


        [HttpGet("GetLeadersByGroupId")]
        public async Task<IActionResult> GetLeadersByGroupId(int groupId) => Ok(await _userRepository.GetLeadersByGroupIdAsync(groupId));

        [HttpGet("GetStudentsByGroupId")]
        public async Task<IActionResult> GetStudentsByGroupId(int groupId) => Ok(await _userRepository.GetStudentsByGroupIdAsync(groupId));

        [HttpGet("GetUnverifiedUsersByRoleId")]
        public async Task<IActionResult> GetUnverifiedUserByRoleId(int roleId) => Ok(await _userRepository.GetUnassignedAndUnverifiedUsers_ByRoleId(roleId));

        [HttpGet("GetAdmins")]
        public async Task<IActionResult> GetAdmins() => Ok(await _userRepository.GetAdminsAsync());

        [HttpGet("GetLeaders")]
        public async Task<IActionResult> GetLeaders() => Ok(await _userRepository.GetLeadersAsync());

        [HttpPut("VerifyUser")]
        public async Task<IActionResult> VerifyUser(int userId, int groupId) => Ok(await _userRepository.VerifyUserAsync(userId, groupId));

        [HttpPut("UpdateUserReadingStreak")]

        public async Task<IActionResult> UpdateUserReadingStreak(int userId) => Ok(await _userRepository.PlusUserReadingStreakAsync(userId));

    }
}
