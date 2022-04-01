using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disney.Core.Entities
{
    public class Movie : BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreatingDate { get; set; }
        
        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Qualification { get; set; }

        public ICollection<Character> Characters { get; set; }

        public ICollection<Gender> Genders { get; set; }

        public Movie()
        {
            CreatingDate = DateTime.Now;
        }
    }
}