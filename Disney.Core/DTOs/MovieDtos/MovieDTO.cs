using System;
using System.Collections.Generic;
using Disney.Core.Entities;

namespace Disney.Core.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime CreatingDate { get; set; }

        public int Qualification { get; set; }

        public ICollection<Character> Characters { get; set; }

        public Gender Gender { get; set; }
    }
}