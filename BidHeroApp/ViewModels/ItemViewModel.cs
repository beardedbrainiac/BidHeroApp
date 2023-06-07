using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public SelectListItem Category { get; set; } = null!;
    }
}
