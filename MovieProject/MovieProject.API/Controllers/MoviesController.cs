using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.API.DTOs;
using MovieProject.API.Filters;
using MovieProject.Core.Models;
using MovieProject.Core.Services;

namespace MovieProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;
        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            return Ok(_mapper.Map<MovieDto>(movie));
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetWithCategoryById(int id)
        {
            var movie = await _movieService.GetWithCategoryByIdAsync(id);

            return Ok(_mapper.Map<MovieWithCategoryDto>(movie));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(MovieDto movieDto)
        {
            var newMovie = await _movieService.AddAsync(_mapper.Map<Movie>(movieDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(newMovie));
        }
        [HttpPut]
        public IActionResult Update(MovieDto movieDto)
        {
            var movie = _movieService.Update(_mapper.Map<Movie>(movieDto));

            return NoContent();
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var movie = _movieService.GetByIdAsync(id).Result;

            _movieService.Remove(movie);

            return NoContent();
        }
    }
}
