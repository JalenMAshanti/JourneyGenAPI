using Dapper;
using JSMS.Persitence.Abstractions;
using JSMS.Persitence.DataTransferObjects;
using System.Data;

namespace JSMS.Persitence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _db;

        public UserRepository(IDbConnection connection)
        {
            _db = connection;
        }


        public async Task<int> DeleteUserAsync(int id)
        {
            string sql = "DELETE FROM user WHERE Id = @Id;";
            var rowsAffected = await _db.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }

        public async Task<IEnumerable<User_DTO>> GetAllUsersAsync()
        {
            string sql = "SELECT Id, FirstName, LastName, Gender, Grade, IsActive, IsVerified, Email, RoleId, GroupId FROM user;";
            try
            {
                var users = await _db.QueryAsync<User_DTO>(sql);

                if (users is null)
                {

                    return new List<User_DTO>();
                }

                return users;
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                return new List<User_DTO>();
            }
        }

        public async Task<User_DTO> GetUserByIdAsync(int id)
        {
            string sql = "SELECT * FROM user WHERE Id = @Id";

            try
            {
                User_DTO? user = await _db.QuerySingleOrDefaultAsync<User_DTO>(sql, new { Id = id });

                if (user is null)
                {
                    return new User_DTO();
                }

                return user;
            }
            catch (Exception ex)
            {
                string message = ex.Message;

                return new User_DTO();
            }
        }

        public async Task<IEnumerable<User_DTO>> GetLeadersByGroupIdAsync(int groupId)
        {
            string sql = "SELECT * FROM user WHERE GroupId = @GroupId AND RoleId > 1;";
            var result = await _db.QueryAsync<User_DTO>(sql, new { GroupId = groupId });
            return result;
        }

        public async Task<IEnumerable<User_DTO>> GetStudentsByGroupIdAsync(int groupId)
        {
            string sql = "SELECT * FROM user WHERE GroupId = @GroupId AND RoleId = 1;";
            var result = await _db.QueryAsync<User_DTO>(sql, new { GroupId = groupId });
            return result;
        }

        public async Task<IEnumerable<User_DTO>> GetUnassignedAndUnverifiedUsers_ByRoleId(int roleId)
        {
            string sql = "SELECT * FROM user WHERE RoleId = @RoleId AND IsVerified IS NULL;";
            var result = await _db.QueryAsync<User_DTO>(sql, new { RoleId = roleId });
            return result;
        }

        public async Task<IEnumerable<User_DTO>> GetAdminsAsync()
        {
            string sql = "SELECT * FROM user WHERE RoleId = 3";
            var result = await _db.QueryAsync<User_DTO>(sql);
            return result;
        }

        public async Task<IEnumerable<User_DTO>> GetLeadersAsync()
        {
            string sql = "SELECT * FROM user WHERE RoleId > 1 AND IsVerified = true";
            var result = await _db.QueryAsync<User_DTO>(sql);
            return result;
        }
    }
}
