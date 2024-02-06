using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowDto, Show>();

            CreateMap<Show, ShowDto>();

        }    
    }
}
