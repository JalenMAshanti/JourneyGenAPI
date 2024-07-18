
using JSMS.Domain.Models;
using JSMS.Persitence.Models.Register;


namespace JSMS.Persitence.Mappers
{
    public static class RegisterRequestMapper
    {
        public static User RegisterMapper(RegisterRequest request) 
        {
            User user = new User();

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.Gender = request.Gender;
            user.Password = request.Password;
            
            return user;            
        }
    }
}
