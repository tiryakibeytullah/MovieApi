using MovieProject.Core.Models;
using MovieProject.Core.Repositories;
using MovieProject.Core.Services;
using MovieProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieProject.Service.Services
{
    public class CinemaService : Service<Cinema>, ICinemaService
    {
        public CinemaService(IUnitOfWork unitOfWork, IRepository<Cinema> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Cinema> GetWithMovieByIdAsync(int cinemaId)
        {
            return await _unitOfWork.Cinemas.GetWithMovieByIdAsync(cinemaId);
        }
    }
}
