using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>();
            CreateMap<Movie, MovieDto>();

        }
    }
}
