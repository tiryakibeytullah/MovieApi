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
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Category> GetWithMoviesByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithMoviesByIdAsync(categoryId);
        }
    }
}
