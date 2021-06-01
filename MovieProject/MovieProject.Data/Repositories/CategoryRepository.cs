using Microsoft.EntityFrameworkCore;
using MovieProject.Core.Models;
using MovieProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Category> GetWithMoviesByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Movies).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
