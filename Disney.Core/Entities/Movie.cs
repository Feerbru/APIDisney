using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        public int GenderId { get; set; }

        public Gender Gender { get; set; }


        public class Mapping
        {
            public Mapping(EntityTypeBuilder<Movie> mappingMovie)
            {
                mappingMovie.HasKey(x => x.Id);
                mappingMovie.HasOne(x => x.Gender);
            }
        }
    }
}