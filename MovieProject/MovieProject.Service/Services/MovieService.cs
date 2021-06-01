using MovieProject.Core.Models;
using MovieProject.Core.Repositories;
using MovieProject.Core.Services;
using MovieProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Service.Services
{
    public class MovieService : Service<Movie>, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork, IRepository<Movie> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Movie> GetWithCategoryByIdAsync(int movieId)
        {
            return await _unitOfWork.Movies.GetWithCategoryByIdAsync(movieId);
        }
    }
}
