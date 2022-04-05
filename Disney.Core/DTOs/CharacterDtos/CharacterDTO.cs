using System.Collections.Generic;
using Disney.Core.DTOs.MovieDtos;

namespace Disney.Core.DTOs.CharacterDtos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string History { get; set; }
        public string Image { get; set; }
        public ICollection<MovieOutDto> Movies { get; set; }
        
    }
}