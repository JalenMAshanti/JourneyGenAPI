using JSMS.Persitence.DataTransferObjects;

namespace JSMS.Persitence.Abstractions
{
    public interface IUserRepository
    {
        Task<User_DTO> GetUserByIdAsync(int id);

        Task<IEnumerable<User_DTO>> GetAllUsersAsync();

        Task<int> DeleteUserAsync(int id);
    }
}
