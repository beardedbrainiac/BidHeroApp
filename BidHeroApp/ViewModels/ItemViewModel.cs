using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BidHeroApp.ViewModels
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Code { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; }

        public SelectListItem Category { get; set; } = null!;
    }
}
