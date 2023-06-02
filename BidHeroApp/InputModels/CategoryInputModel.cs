namespace BidHeroApp.InputModels
{
    public class CategoryInputModel : BaseInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
