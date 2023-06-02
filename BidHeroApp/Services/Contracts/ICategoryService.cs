using BidHeroApp.InputModels;
using BidHeroApp.ViewModels;

namespace BidHeroApp.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IList<CategoryViewModel>> ListAsync();
        Task<CategoryViewModel> AddAsync(CategoryInputModel model);
        Task<CategoryViewModel> UpdateAsync(CategoryInputModel model);
        Task<CategoryViewModel> DeleteAsync(DeleteInputModel model);
    }
}
