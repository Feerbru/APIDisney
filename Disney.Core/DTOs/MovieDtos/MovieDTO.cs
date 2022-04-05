using System;
using System.Collections.Generic;
using Disney.Core.DTOs.CharacterDtos;

namespace Disney.Core.DTOs.MovieDtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreatingDate { get; set; }

        public int Qualification { get; set; }

        public ICollection<CharacterOutDto> Characters { get; set; }

    }
}