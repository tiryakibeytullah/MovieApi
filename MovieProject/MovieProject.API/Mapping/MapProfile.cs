using AutoMapper;
using MovieProject.API.DTOs;
using MovieProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.API.Mapping
{
    public class MapProfile : Profile
    {   // Hangi veriler birbirlerine çevirilebilir(dönüştürülebilir), onu burada belirtiyoruz.
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryWithMovieDto>();
            CreateMap<CategoryWithMovieDto, Category>();

            CreateMap<Movie, MovieDto>();
            CreateMap<MovieDto, Movie>();

            CreateMap<Movie, MovieWithCategoryDto>();
            CreateMap<MovieWithCategoryDto, Movie>();

            CreateMap<Cinema, CinemaDto>();
            CreateMap<CinemaDto, Cinema>();

            CreateMap<Cinema, CinemaWithMovieDto>();
            CreateMap<CinemaWithMovieDto, Cinema>();
        }
    }
}
