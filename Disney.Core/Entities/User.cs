using System;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public DateTime DischargeDate { get; set; }

        public bool Active { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}