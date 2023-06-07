using Microsoft.AspNetCore.Mvc.Rendering;

namespace BidHeroApp.InputModels
{
    public class ItemsInputModel : BaseInputModel
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public SelectListItem Category { get; set; } = null!;
    }
}
