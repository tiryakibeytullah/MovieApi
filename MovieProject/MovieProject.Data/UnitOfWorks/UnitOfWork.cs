using MovieProject.Core.Repositories;
using MovieProject.Core.UnitOfWorks;
using MovieProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private MovieRepository _movieRepository;
        private CategoryRepository _categoryRepository;
        private CinemaRepository _cinemaRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }
        public IMovieRepository Movies => this._movieRepository = _movieRepository ?? new MovieRepository(_context);

        public ICategoryRepository Categories => this._categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public ICinemaRepository Cinemas => this._cinemaRepository = _cinemaRepository ?? new CinemaRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
