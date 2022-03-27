using System;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace Disney.Core.DTOs
{
    public class CreationMovieDTO
    {
        public CreationMovieDTO()
        {
            this.CreatingDate = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        public string Title { get; set; }

        public IFormFile Image { get; set; }

        public string CreatingDate { get; }

        public int Qualification { get; set; }
        
        

    }
}