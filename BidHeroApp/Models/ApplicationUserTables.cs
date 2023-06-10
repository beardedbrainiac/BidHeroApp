namespace BidHeroApp.Models
{
    public partial class ApplicationUser
    {
        public virtual ICollection<Bid> BidCreatedByUsers { get; set; } = new List<Bid>();

        public virtual ICollection<Bid> BidDeletedByUsers { get; set; } = new List<Bid>();

        public virtual ICollection<Bid> BidUpdatedByUsers { get; set; } = new List<Bid>();
        public virtual ICollection<Category> CategoryCreatedByUsers { get; set; } = new List<Category>();

        public virtual ICollection<Category> CategoryDeletedByUsers { get; set; } = new List<Category>();

        public virtual ICollection<Category> CategoryUpdatedByUsers { get; set; } = new List<Category>();

        public virtual ICollection<Item> ItemCreatedByUsers { get; set; } = new List<Item>();

        public virtual ICollection<Item> ItemDeletedByUsers { get; set; } = new List<Item>();

        public virtual ICollection<Item> ItemUpdatedByUsers { get; set; } = new List<Item>();
    }
}
