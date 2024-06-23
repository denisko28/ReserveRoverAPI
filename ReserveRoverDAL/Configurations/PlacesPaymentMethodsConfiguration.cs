using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class PlacesPaymentMethodsConfiguration : IEntityTypeConfiguration<PlacePaymentMethod>
{
    public void Configure(EntityTypeBuilder<PlacePaymentMethod> builder)
    {
        builder.HasKey(e => new { e.PlaceId, e.Method }).HasName("place_payment_methods_pkey");

        builder.ToTable("place_payment_methods");

        builder.Property(e => e.PlaceId).HasColumnName("place_id");
        builder.Property(e => e.Method).HasColumnName("method");

        builder.HasOne(d => d.Place).WithMany(p => p.PlacePaymentMethods)
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("place_payment_methods_place_id_fkey");
        
        // new PlacesPaymentsSeeder().Seed(builder);
    }
}