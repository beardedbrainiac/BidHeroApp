using AutoMapper;
using BidHeroApp.Models;
using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.Mappers
{
    public class ItemMap : Profile
    {
        public ItemMap()
        {
            CreateMap<Item, ItemViewModel>()
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => new SelectListItem()
                    {
                        Value = src.CategoryId.ToString(),
                        Text = src.Category.Name,
                    }));
        }
    }
}
