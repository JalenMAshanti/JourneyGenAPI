using Dapper;
using JSMS.Persitence.Abstractions;
using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.Models.Login;
using System.Data;

namespace JSMS.Persitence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _db;

        public LoginRepository(IDbConnection connection)
        {
            _db = connection;
        }

        public async Task<Login_DTO> LoginUserAsync(LoginRequest request)
        {
            string? sql = "SELECT Email, Password, RoleID FROM user WHERE Email = @Email AND Password = @Password";

            try
            {
                var result = await _db.QuerySingleOrDefaultAsync<Login_DTO>(sql, new { Email = request.Email, Password = request.Password });
                
                if (result == null) 
                {
                    return new Login_DTO();
                }
                return result;
            
            }
            catch (Exception ex) { 
                
                string message = ex.Message;
                return new Login_DTO(); 
            }        
        }
    }
}
