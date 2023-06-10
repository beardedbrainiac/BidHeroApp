using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.ViewModels
{
    public class AuctionItemViewModel
    {
        public SelectListItem Category { get; set; } = null!;
        public SelectListItem Item { get; set; } = null!;
        public string Image { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
