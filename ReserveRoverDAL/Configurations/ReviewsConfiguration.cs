using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class ReviewsConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(e => e.Id).HasName("reviews_pkey");

        builder.ToTable("reviews");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");
        builder.Property(e => e.AuthorId)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("author_id");
        builder.Property(e => e.Comment)
            .HasMaxLength(5000)
            .HasColumnName("comment");
        builder.Property(e => e.CreationDate).HasColumnName("creation_date");
        builder.Property(e => e.Mark)
            .HasPrecision(1)
            .HasColumnName("mark");
        builder.Property(e => e.PlaceId).HasColumnName("place_id");

        builder.HasOne(d => d.Place).WithMany(p => p.Reviews)
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("reviews_place_id_fkey");
        
        // new ReviewsSeeder().Seed(builder);
    }
}