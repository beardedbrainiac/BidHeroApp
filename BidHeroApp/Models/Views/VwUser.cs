namespace BidHeroApp.Models.Views
{
    public class VwUser
    {
        public string Id { get; set; } = null!;

        public string? GivenName { get; set; }

        public string? FamilyName { get; set; }

        public string? Email { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
