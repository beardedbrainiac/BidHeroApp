using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.ViewModels
{
    public class AuctionItemViewModel
    {
        public SelectListItem Category { get; set; } = null!;
        public SelectListItem Item { get; set; } = null!;
        public int Points { get; set; }
    }
}
