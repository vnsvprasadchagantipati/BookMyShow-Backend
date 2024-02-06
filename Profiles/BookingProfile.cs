using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDto, Booking>().ForMember(dest => dest.Show, opt => opt.Ignore()) // Assuming Show is a related entity
                .ForMember(dest => dest.User, opt => opt.Ignore()); // Assuming User is a related entity
            ;
            CreateMap<Booking, BookingDto>().ForMember(dest => dest.ShowID, opt => opt.MapFrom(src => src.ShowID))  // Map ShowID to ShowID in BookingDto
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));  // Map UserID to UserID in BookingDto
        
        }
    }
}
