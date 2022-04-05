using System;
using System.ComponentModel.DataAnnotations;
using Disney.Core.Enumerations;

namespace Disney.Core.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Ingresar un correo valido!")]
        public string Email { get; set; }
        
        public RoleType Role { get; set; }
        
        public byte[] PasswordHash { get; set; }
        
        public byte[] PasswordSalt { get; set; }
    }
}