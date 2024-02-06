using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class MultiplexProfile : Profile
    {
        public MultiplexProfile() 
        {
            CreateMap<MultiplexDto, Multiplex>();
            CreateMap<Multiplex, MultiplexDto>();
        }   
    }
}
