using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BidHeroApp.Models.Enums;

namespace BidHeroApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string? GivenName { get; set; }

        [StringLength(100)]
        public string? FamilyName { get; set; }

        public Gender? Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? BirthDate { get; set; }
    }
}
