using BidHeroApp.InputModels;
using BidHeroApp.ViewModels;

namespace BidHeroApp.Services.Contracts
{
    public interface IItemService
    {
        Task<IList<ItemViewModel>> ListAsync();
        Task<ItemViewModel> AddAsync(ItemInputModel model);
        Task<IList<ItemViewModel>> AddRangeAsync(ItemsInputModel model);
        Task<ItemViewModel> UpdateAsync(ItemInputModel model);
        Task<ItemViewModel> DeleteAsync(DeleteInputModel model);
    }
}
