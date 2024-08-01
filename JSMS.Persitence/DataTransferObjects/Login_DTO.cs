namespace JSMS.Persitence.DataTransferObjects
{
    public class Login_DTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }   
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int GroupId { get; set; }
        public int Grade { get; set; }
        public long PhoneNumber { get; set; }
        public string? TempKey { get; set; }

    }
}
