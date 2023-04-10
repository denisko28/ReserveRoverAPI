using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class PlacesDescriptionsConfiguration : IEntityTypeConfiguration<PlacesDescription>
{
    public void Configure(EntityTypeBuilder<PlacesDescription> builder)
    {
        builder.HasKey(e => e.PlaceId).HasName("places_descriptions_pkey");

        builder.ToTable("places_descriptions");

        builder.Property(e => e.Description)
            .HasMaxLength(1500)
            .HasColumnName("description");
        builder.Property(e => e.PlaceId).HasColumnName("place_id");

        builder.HasOne(d => d.Place).WithMany()
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("places_descriptions_place_id_fkey");

        new PlacesDescriptionsSeeder().Seed(builder);
    }
}