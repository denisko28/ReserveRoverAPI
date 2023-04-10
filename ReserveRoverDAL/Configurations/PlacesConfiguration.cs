using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class PlacesConfiguration : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.HasKey(e => e.Id).HasName("places_pkey");

        builder.ToTable("places");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Address)
            .HasMaxLength(120)
            .HasColumnName("address");
        builder.Property(e => e.AvgBill)
            .HasPrecision(7, 2)
            .HasColumnName("avg_bill");
        builder.Property(e => e.AvgMark)
            .HasPrecision(2, 1)
            .HasColumnName("avg_mark");
        builder.Property(e => e.CityId).HasColumnName("city_id");
        builder.Property(e => e.ClosesAt).HasColumnName("closes_at");
        builder.Property(e => e.ManagerId)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("manager_id");
        builder.Property(e => e.ModerationStatus).HasColumnName("moderation_status");
        builder.Property(e => e.OpensAt).HasColumnName("opens_at");
        builder.Property(e => e.PublicDate).HasColumnName("public_date");
        builder.Property(e => e.Title)
            .HasMaxLength(80)
            .HasColumnName("title");

        builder.HasOne(d => d.City).WithMany(p => p.Places)
            .HasForeignKey(d => d.CityId)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("places_city_id_fkey");
        
        new PlacesSeeder().Seed(builder);
    }
}