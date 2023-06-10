namespace BidHeroApp.Models
{
    public class Bid : BaseEntity
    {
        public int Points { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; } = null!;
    }
}
