using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieProject.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) // Bir request Executing yani geldiği zaman kontrol edicem.
        {
            if (!context.ModelState.IsValid)
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 400;
                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(v => v.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    errorDto.Errors.Add(x.ErrorMessage);
                });

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}
