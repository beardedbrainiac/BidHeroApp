using AutoMapper;
using BidHeroApp.Models;
using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.Mappers
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<Category, SelectListItem>()
                .ForMember(dest => dest.Text,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value,
                    opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
