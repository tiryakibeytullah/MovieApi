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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this._categoryService = categoryService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories)); // 200 durum kodu.
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(_mapper.Map<CategoryDto>(category));
        }
        [HttpGet("{id}/movies")]
        public async Task<IActionResult> GetWithMovieById(int id)
        {
            var category = await _categoryService.GetWithMoviesByIdAsync(id);

            return Ok(_mapper.Map<CategoryWithMovieDto>(category));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory)); // 201 durum kodu.
        }
        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDto));

            return NoContent(); // 204 durum kodu.
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var removeCategory = _categoryService.GetByIdAsync(id).Result; // Result methody async'a çevirir.

            _categoryService.Remove(removeCategory);

            return NoContent();
        }
    }
}
