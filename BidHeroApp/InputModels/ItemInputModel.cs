using System.ComponentModel.DataAnnotations;

namespace BidHeroApp.InputModels
{
    public class ItemInputModel : BaseInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Code { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;

        [DataType(DataType.Date)]
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;

        public int Category { get; set; }
    }
}
