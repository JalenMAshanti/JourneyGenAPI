namespace JSMS.Persitence.DataTransferObjects
{
    public class User_DTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int RoleId { get; set; }
        public long PhoneNumber { get; set; }
        public int GroupId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
      
    }
}
