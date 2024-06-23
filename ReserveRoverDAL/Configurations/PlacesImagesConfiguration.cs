using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class PlacesImagesConfiguration : IEntityTypeConfiguration<PlaceImage>
{
    public void Configure(EntityTypeBuilder<PlaceImage> builder)
    {
        builder.HasKey(e => new { e.PlaceId, e.SequenceIndex }).HasName("place_images_pkey");

        builder.ToTable("place_images");

        builder.Property(e => e.PlaceId).HasColumnName("place_id");
        builder.Property(e => e.SequenceIndex).HasColumnName("sequence_index");
        builder.Property(e => e.ImageUrl)
            .HasMaxLength(105)
            .HasColumnName("image_url");

        builder.HasOne(d => d.Place).WithMany(p => p.PlaceImages)
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("place_images_place_id_fkey");

        // new PlacesImagesSeeder().Seed(builder);
    }
}