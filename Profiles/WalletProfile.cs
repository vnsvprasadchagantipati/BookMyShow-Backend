using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletDto, Wallet>();
            CreateMap<Wallet, WalletDto>();
        }  
    }
}
