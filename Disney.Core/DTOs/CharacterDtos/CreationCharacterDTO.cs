using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace Disney.Core.DTOs
{
    public class CreationCharacterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public string History { get; set; }
        public IFormFile Image { get; set; }
    }
}