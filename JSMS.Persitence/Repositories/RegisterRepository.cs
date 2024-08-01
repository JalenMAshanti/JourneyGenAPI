using Dapper;
using JSMS.Domain.Models;
using System.Data;
using System.Security.Policy;

namespace JSMS.Persitence.Repositories
{
    public class RegisterRepository
    {
        private readonly IDbConnection _db;

        public RegisterRepository(IDbConnection connection)
        {
            _db = connection;
        }

        public async Task RegisterUserAsync(User user)
        {
            string? sql = "INSERT INTO user (Id, FirstName, LastName, Email, Gender, RoleId, PhoneNumber, Grade, Password) VALUES (FLOOR(100000 + RAND() * 900000), @FirstName, @LastName, @Email, @Gender, @RoleId, @PhoneNumber, @Grade, @Password);";
            await _db.ExecuteAsync(sql, 
            new {
                    FirstName = user.FirstName, 
                    LastName = user.LastName, 
                    Email = user.Email, 
                    Grade = user.Grade, 
                    Gender = user.Gender, 
                    RoleId = user.RoleId, 
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password
            });
        }
    }
}

