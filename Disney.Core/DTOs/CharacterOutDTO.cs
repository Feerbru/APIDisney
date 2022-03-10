using System.Collections.Generic;
using Disney.Core.Entities;

namespace Disney.Core.DTOs
{
    public class CharacterOutDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public string Image { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
    }

    public class MovieDto
    {
        public string Title { get; set; }

        public string Image { get; set; }
        
        public int Qualification { get; set; }
        
        
    }
}