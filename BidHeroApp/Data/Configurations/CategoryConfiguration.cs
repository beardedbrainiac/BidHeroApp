using BidHeroApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BidHeroApp.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.Property(e => e.CreatedByUserId).HasMaxLength(450);
            builder.Property(e => e.CreatedDate).HasDefaultValueSql("(getutcdate())");
            builder.Property(e => e.DeletedByUserId).HasMaxLength(450);
            builder.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.UpdatedByUserId).HasMaxLength(450);

            builder.HasOne(d => d.CreatedByUser).WithMany(p => p.CategoryCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category_CreatedByUser");

            builder.HasOne(d => d.DeletedByUser).WithMany(p => p.CategoryDeletedByUsers)
                .HasForeignKey(d => d.DeletedByUserId)
                .HasConstraintName("FK_Category_DeletedByUser");

            builder.HasOne(d => d.UpdatedByUser).WithMany(p => p.CategoryUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Category_UpdatedByUser");
        }
    }
}
