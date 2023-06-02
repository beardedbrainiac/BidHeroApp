using AutoMapper;
using BidHeroApp.Models;
using BidHeroApp.ViewModels;

namespace BidHeroApp.Mappers
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
