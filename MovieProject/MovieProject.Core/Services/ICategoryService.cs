using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithMoviesByIdAsync(int categoryId);

        // Kategoriye özgü metotlarımız burada tanımlanır.
    }
}
