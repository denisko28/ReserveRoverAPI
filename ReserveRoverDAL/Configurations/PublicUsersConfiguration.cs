using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Configurations;

public class PublicUsersConfiguration : IEntityTypeConfiguration<PublicUser>
{
    public void Configure(EntityTypeBuilder<PublicUser> builder)
    {
        builder.HasKey(e => e.Id).HasName("public_users_pkey");

        builder.ToTable("public_users");

        builder.Property(e => e.Id)
            .HasMaxLength(28)
            .IsFixedLength()
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.FirstName)
            .HasMaxLength(15)
            .HasColumnName("first_name");
        builder.Property(e => e.LastName)
            .HasMaxLength(20)
            .HasColumnName("last_name");
        builder.Property(e => e.Avatar)
            .HasMaxLength(170)
            .HasColumnName("avatar");
    }
}