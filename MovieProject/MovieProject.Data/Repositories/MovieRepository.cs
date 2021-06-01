using Microsoft.EntityFrameworkCore;
using MovieProject.Core.Models;
using MovieProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public MovieRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Movie> GetWithCategoryByIdAsync(int movieId)
        {
            return await this._appDbContext.Movies.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == movieId);
        }
    }
}
