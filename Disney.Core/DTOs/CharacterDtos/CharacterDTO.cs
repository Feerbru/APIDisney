using System;
using System.Collections.Generic;
using Disney.Core.Entities;

namespace Disney.Core.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public string Image { get; set; }
        public ICollection<MovieOutDto> Movies { get; set; }
    }

    public class MovieOutDto
    {
        public string Title { get; set; }

        public string Image { get; set; }
        
        public DateTime CreatingDate { get; set; }
        
        
    }
}