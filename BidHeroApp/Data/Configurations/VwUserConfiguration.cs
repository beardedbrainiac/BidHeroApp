using BidHeroApp.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidHeroApp.Data.Configurations
{
    public class VwUserConfiguration : IEntityTypeConfiguration<VwUser>
    {
        public void Configure(EntityTypeBuilder<VwUser> builder)
        {
            builder
                .HasNoKey()
                .ToView("vwUsers");

            builder.Property(e => e.Email).HasMaxLength(256);
            builder.Property(e => e.FamilyName).HasMaxLength(100);
            builder.Property(e => e.GivenName).HasMaxLength(100);
            builder.Property(e => e.Id).HasMaxLength(450);
        }
    }
}
