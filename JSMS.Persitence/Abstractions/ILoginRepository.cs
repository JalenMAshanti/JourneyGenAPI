using JSMS.Persitence.DataTransferObjects;
using JSMS.Persitence.Models.Login;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Persitence.Abstractions
{
    public interface ILoginRepository
    {
        public Task<Login_DTO> LoginUserAsync(LoginRequest request);

    }
}
