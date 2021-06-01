using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieProject.API.DTOs;
using MovieProject.Core.Models;
using MovieProject.Core.Services;

namespace MovieProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;
        public CinemasController(ICinemaService cinemaService, IMapper mapper)
        {
            this._cinemaService = cinemaService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cinemas = await _cinemaService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CinemaDto>>(cinemas));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cinema = await _cinemaService.GetByIdAsync(id);

            return Ok(_mapper.Map<CinemaDto>(cinema));
        }
        [HttpGet("{id}/movies")]
        public async Task<IActionResult> GetWithMovieById(int id)
        {
            var cinema = await _cinemaService.GetWithMovieByIdAsync(id);

            return Ok(_mapper.Map<CinemaWithMovieDto>(cinema));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CinemaDto cinemaDto)
        {
            var newCinema = await _cinemaService.AddAsync(_mapper.Map<Cinema>(cinemaDto));

            return Created(string.Empty, _mapper.Map<CinemaDto>(newCinema));
        }
        [HttpPut]
        public IActionResult Update(CinemaDto cinemaDto)
        {
            var cinema = _cinemaService.Update(_mapper.Map<Cinema>(cinemaDto));

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var cinema = _cinemaService.GetByIdAsync(id).Result;
            _cinemaService.Remove(cinema);

            return NoContent();
        }
    }
}
