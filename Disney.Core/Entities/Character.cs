using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Character : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [Range(1,99, ErrorMessage = "Edad incorrecta")]
        public int Age { get; set; }
        
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public double Weight { get; set; }

        [Required]
        [StringLength(200)]
        public string History { get; set; }

        public string Image { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}