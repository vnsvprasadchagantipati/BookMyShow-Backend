using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {

            CreateMap<CouponDto, Coupon>();
            CreateMap<Coupon, CouponDto>();
        }
    }
}

    

