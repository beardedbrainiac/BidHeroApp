using BidHeroApp.InputModels;
using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IList<SelectListItem>> AsSelectListAsync();
        Task<IList<CategoryViewModel>> ListAsync();
        Task<CategoryViewModel> AddAsync(CategoryInputModel model);
        Task<CategoryViewModel> UpdateAsync(CategoryInputModel model);
        Task<CategoryViewModel> DeleteAsync(DeleteInputModel model);
    }
}
