using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Repositories
{   // Sinema salonuna ait özel işlemler burada tanımlanır.
    public interface ICinemaRepository : IRepository<Cinema>
    {
        Task<Cinema> GetWithMovieByIdAsync(int cinemaId); // vermiş olduğum sinema id'sine göre hem sinema salon ismi, hemde o salona ait filmler listelenicek.
    }
}
