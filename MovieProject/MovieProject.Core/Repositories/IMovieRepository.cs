using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Repositories
{   // Filme ait özel işlemlerin bulunduğu metotlar burada tanımlanır.
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<Movie> GetWithCategoryByIdAsync(int movieId); // Vermiş olduğum film id'sine göre hem filmin bilgileri hem de filmin hangi kategoriye ait olduğu gösterilir.
    }
}
