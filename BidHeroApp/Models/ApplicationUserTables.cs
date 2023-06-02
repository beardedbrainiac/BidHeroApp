namespace BidHeroApp.Models
{
    public partial class ApplicationUser
    {
        public virtual ICollection<Category> CategoryCreatedByUsers { get; set; } = new List<Category>();

        public virtual ICollection<Category> CategoryDeletedByUsers { get; set; } = new List<Category>();

        public virtual ICollection<Category> CategoryUpdatedByUsers { get; set; } = new List<Category>();
    }
}
