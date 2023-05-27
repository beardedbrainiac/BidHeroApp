using System.ComponentModel.DataAnnotations;

namespace BidHeroApp.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? GivenName { get; set; }

        [StringLength(100)]
        public string? FamilyName { get; set; }

        public string Email { get; set; } = string.Empty;

        public bool IsAdmin { get; set; }
    }
}
