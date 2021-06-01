using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieProject.API.DTOs;
using MovieProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        private readonly IMovieService _movieService;
        public NotFoundFilter(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var movie = await _movieService.GetByIdAsync(id);

            if (movie != null)
            {
                await next(); // kodu işlemeye devam et. request'i devam ettiriyorum.
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;

                errorDto.Errors.Add($"Id'si {id} olan film veritabanında bulunamadı.");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
