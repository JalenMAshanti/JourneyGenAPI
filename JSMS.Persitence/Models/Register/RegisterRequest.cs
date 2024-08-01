
namespace JSMS.Persitence.Models.Register
{
    public class RegisterRequest
    {
        public RegisterRequest(string? firstName, string? lastName, string? email, string? gender, int grade, long phoneNumber, string password, int roleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Grade = grade;
            PhoneNumber = phoneNumber;
            Password = password;
            RoleId = roleId;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int RoleId { get; set; }
        public int Grade { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }

    }
}
