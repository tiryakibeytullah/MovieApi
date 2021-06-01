using Microsoft.EntityFrameworkCore;
using MovieProject.Core.Models;
using MovieProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.Repositories
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CinemaRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Cinema> GetWithMovieByIdAsync(int cinemaId)
        {
            return await _appDbContext.Cinemas.Include(x => x.Movies).SingleOrDefaultAsync(x => x.Id == cinemaId);
        }
    }
}
