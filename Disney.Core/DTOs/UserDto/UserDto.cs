using Disney.Core.Enumerations;

namespace Disney.Core.DTOs.UserDto
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public RoleType? Role { get; set; }
        
        //public byte[] PasswordHash { get; set; }
        
       // public byte[] PasswordSalt { get; set; }
    }
}