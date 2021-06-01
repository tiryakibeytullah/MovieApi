using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Services
{   // Ekstra veritabanı ile ilgili işlemi olmayan, movie nesnesi içerisinde kendine ait işlemler var ise burada tanımlanır.
    public interface IMovieService : IService<Movie>
    {
        Task<Movie> GetWithCategoryByIdAsync(int movieId);
    }
}
