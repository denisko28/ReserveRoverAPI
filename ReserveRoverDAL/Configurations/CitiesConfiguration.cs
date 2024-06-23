using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class CitiesConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id).HasName("cities_pkey");

        builder.ToTable("cities");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .HasMaxLength(80)
            .HasColumnName("name");
        
        // new CitiesSeeder().Seed(builder);
    }
}