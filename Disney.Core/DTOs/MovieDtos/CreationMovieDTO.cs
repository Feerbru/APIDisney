using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Disney.Core.DTOs.MovieDtos
{
    public class CreationMovieDto
    {
        [Required]
        public string Title { get; set; }

        public IFormFile Image { get; set; }

        [Required]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public int Qualification { get; set; }
        
    }
}