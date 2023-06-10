using BidHeroApp.ViewModels;
using Microsoft.AspNetCore.SignalR;

namespace BidHeroApp.Hubs
{
    public class AuctionHub : Hub
    {
        public async Task RefreshAuctions(List<AuctionItemViewModel> auctions)
        {
            await Clients.All.SendAsync("RefreshAuctions", auctions);
        }
    }
}
