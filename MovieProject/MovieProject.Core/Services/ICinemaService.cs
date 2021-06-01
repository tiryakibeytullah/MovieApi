using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Services
{
    public interface ICinemaService : IService<Cinema>
    {
        Task<Cinema> GetWithMovieByIdAsync(int cinemaId);
    }
}
