using BidHeroApp.ViewModels;

namespace BidHeroApp.Services.Contracts
{
    public interface IAuctionService
    {
        Task<IList<AuctionItemViewModel>> ListAsync(int? categoryId);
    }
}
