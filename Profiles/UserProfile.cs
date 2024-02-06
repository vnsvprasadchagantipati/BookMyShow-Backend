using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
   
    
        public class UserProfile : Profile
        {
            public UserProfile()
            {
                CreateMap<User, UserDto>();
                CreateMap<UserDto, User>();
            }
        }
    }


