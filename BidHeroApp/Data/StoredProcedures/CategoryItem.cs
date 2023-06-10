namespace BidHeroApp.Data.StoredProcedures
{
    public class CategoryItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int? Points { get; set; }
    }
}
