using JSMS.Persitence.DataTransferObjects;

namespace JSMS.Persitence.Abstractions
{
    public interface IUserRepository
    {
        Task<User_DTO> GetUserByIdAsync(int id);

        Task<IEnumerable<User_DTO>> GetAllUsersAsync();

        Task<int> DeleteUserAsync(int id);

        Task<IEnumerable<User_DTO>> GetLeadersByGroupIdAsync(int GroupId);

        Task<IEnumerable<User_DTO>> GetStudentsByGroupIdAsync(int GroupId);

        public Task<IEnumerable<User_DTO>> GetUnassignedAndUnverifiedUsers_ByRoleId(int roleId);

        public Task<IEnumerable<User_DTO>> GetAdminsAsync();

        public Task<IEnumerable<User_DTO>> GetLeadersAsync();
    }
}
