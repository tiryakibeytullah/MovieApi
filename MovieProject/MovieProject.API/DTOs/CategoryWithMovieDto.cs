using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class CategoryWithMovieDto : CategoryDto
    {
        public ICollection<MovieDto> Movies { get; set; }
    }
}
