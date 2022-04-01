using System.Collections.Generic;

namespace Disney.Core.Entities
{
    public class Gender : BaseEntity
    {
        
        public string Name { get; set; }

        public string Image { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}