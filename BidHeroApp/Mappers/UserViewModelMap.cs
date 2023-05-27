using AutoMapper;
using BidHeroApp.Models.Views;
using BidHeroApp.ViewModels;

namespace BidHeroApp.Mappers
{
    public class UserViewModelMap : Profile
    {
        public UserViewModelMap()
        {
            CreateMap<VwUser, UserViewModel>();
        }
    }
}
