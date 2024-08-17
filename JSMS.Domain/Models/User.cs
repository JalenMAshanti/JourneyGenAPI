namespace JSMS.Domain.Models
{
    public class User
    {
        public User() { }

        public User(int id, string? firstName, string? lastName, string? email, string? gender, int grade, int roleId, long phoneNumber, int groupId, bool isActive, bool isVerified, string password, int readingStreak)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Grade = grade;
            RoleId = roleId;
            PhoneNumber = phoneNumber;
            GroupId = groupId;
            IsActive = isActive;
            IsVerified = isVerified;
            Password = password;
            ReadingStreak = readingStreak;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Gender { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public int Grade { get; set; }
        public long PhoneNumber { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; } = false;
        public bool IsVerified { get; set; } = false;
        public string? Password { get; set; }
        public int ReadingStreak { get; set; }
    }
}
