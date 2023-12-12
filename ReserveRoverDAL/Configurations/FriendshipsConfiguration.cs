using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Configurations;

public class FriendshipsConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(e => e.Id).HasName("friendships_pkey");

        builder.ToTable("friendships");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.User1Id)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("user1_id");
        builder.Property(e => e.User2Id)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("user2_id");
        builder.Property(e => e.RequestedDateTime).HasColumnName("requested_date_time");
        builder.Property(e => e.Accepted).HasColumnName("accepted");
        
        builder.HasIndex(a => new { a.User1Id, a.User2Id}).IsUnique();
        
        builder.HasOne(d => d.User1).WithMany(p => p.FriendshipsUser1)
            .HasForeignKey(d => d.User1Id)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("friendship_public_user1_fkey");
        builder.HasOne(d => d.User2).WithMany(p => p.FriendshipsUser2)
            .HasForeignKey(d => d.User2Id)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("friendship_public_user2_fkey");
        
        // new FriendshipsSeeder().Seed(builder);
    }
}