namespace BidHeroApp.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

        public string CreatedByUserId { get; set; } = string.Empty;

        public ApplicationUser CreatedByUser { get; set; } = null!;

        public DateTimeOffset CreatedDate { get; set; }

        public string? UpdatedByUserId { get; set; }

        public ApplicationUser? UpdatedByUser { get; set; }

        public DateTimeOffset? UpdatedDate { get; set; }

        public string? DeletedByUserId { get; set; }

        public ApplicationUser? DeletedByUser { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }
    }
}
