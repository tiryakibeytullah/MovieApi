using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Core.Repositories
{   // Sadece kategoriye özgü işlemler yazılır.
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithMoviesByIdAsync(int categoryId); // Vermiş olduğum kategori id'ye göre hem o kategori ismi, hemde o kategoriye ait filmler bana gelicek.
    }
}
