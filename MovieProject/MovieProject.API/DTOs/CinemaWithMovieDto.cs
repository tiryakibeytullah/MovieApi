using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.DTOs
{
    public class CinemaWithMovieDto
    {
        public ICollection<MovieDto> Movies { get; set; }
    }
}
