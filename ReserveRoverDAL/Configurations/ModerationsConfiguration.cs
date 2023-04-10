using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Concrete;

namespace ReserveRoverDAL.Configurations;

public class ModerationsConfiguration : IEntityTypeConfiguration<Moderation>
{

    public void Configure(EntityTypeBuilder<Moderation> builder)
    {
        builder.HasKey(e => e.Id).HasName("moderation_pkey");

        builder.ToTable("moderation");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("gen_random_uuid()")
            .HasColumnName("id");
        builder.Property(e => e.Date).HasColumnName("date");
        builder.Property(e => e.ModeratorId)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("moderator_id");
        builder.Property(e => e.PlaceId).HasColumnName("place_id");
        builder.Property(e => e.Status).HasColumnName("status");

        builder.HasOne(d => d.Place).WithMany(p => p.Moderations)
            .HasForeignKey(d => d.PlaceId)
            .HasConstraintName("moderation_place_id_fkey");
        
        new ModerationsSeeder().Seed(builder);
    }
}