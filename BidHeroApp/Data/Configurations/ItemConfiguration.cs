using BidHeroApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidHeroApp.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.Property(e => e.Code).HasMaxLength(50);
            builder.Property(e => e.CreatedByUserId).HasMaxLength(450);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeletedByUserId).HasMaxLength(450);
            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.UpdatedByUserId).HasMaxLength(450);

            builder.HasOne(d => d.Category).WithMany(p => p.Items)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_Category");

            builder.HasOne(d => d.CreatedByUser).WithMany(p => p.ItemCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Item_CreatedByUser");

            builder.HasOne(d => d.DeletedByUser).WithMany(p => p.ItemDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_Item_DeletedByUser");

            builder.HasOne(d => d.UpdatedByUser).WithMany(p => p.ItemUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Item_UpdatedByUser");
        }
    }
}
