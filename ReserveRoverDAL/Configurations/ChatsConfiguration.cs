using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Configurations;

public class ChatsConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(e => e.Id).HasName("chats_pkey");

        builder.ToTable("chats");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.User1Id)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("user1_id");
        builder.Property(e => e.User2Id)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("user2_id");
        
        builder.HasIndex(a => new { a.User1Id, a.User2Id}).IsUnique();
        
        builder.HasOne(d => d.User1).WithMany(p => p.ChatsUser1)
            .HasForeignKey(d => d.User1Id)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("chat_public_user1_fkey");
        builder.HasOne(d => d.User2).WithMany(p => p.ChatsUser2)
            .HasForeignKey(d => d.User2Id)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("chat_public_user2_fkey");

        // new ChatsSeeder().Seed(builder);
    }
}