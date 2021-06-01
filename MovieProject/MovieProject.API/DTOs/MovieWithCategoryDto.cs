using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class MovieWithCategoryDto : MovieDto
    {
        public CategoryDto Category { get; set; }
    }
}
