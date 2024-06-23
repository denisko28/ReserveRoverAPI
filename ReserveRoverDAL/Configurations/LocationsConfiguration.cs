using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class LocationsConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(e => e.PlaceId).HasName("locations_pkey");

        builder.ToTable("locations");

        builder.Property(e => e.PlaceId)
            .ValueGeneratedNever()
            .HasColumnName("place_id");
        builder.Property(e => e.Latitude)
            .HasPrecision(8, 6)
            .HasColumnName("latitude");
        builder.Property(e => e.Longitude)
            .HasPrecision(8, 6)
            .HasColumnName("longitude");

        builder.HasOne(d => d.Place).WithOne(p => p.Location)
            .HasForeignKey<Location>(d => d.PlaceId)
            .HasConstraintName("locations_place_id_fkey");
        
        // new LocationsSeeder().Seed(builder);
    }
}