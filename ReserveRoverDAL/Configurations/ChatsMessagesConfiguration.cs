using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Configurations;

public class ChatsMessagesConfiguration : IEntityTypeConfiguration<ChatMessage>
{
    public void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        builder.HasKey(e => e.Id).HasName("chats_messages_pkey");

        builder.ToTable("chats_messages");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FromUserId)
            .HasMaxLength(28)
            .IsFixedLength()
            .HasColumnName("from_user_id");
        builder.Property(e => e.Message)
            .HasMaxLength(2048)
            .HasColumnName("message");
        builder.Property(e => e.DateTime)
            .HasMaxLength(120)
            .HasColumnName("date_time");
        builder.Property(e => e.Viewed).HasColumnName("viewed");
        
        builder.HasOne(d => d.Chat).WithMany(p => p.ChatMessages)
            .HasForeignKey(d => d.ChatId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("chat_chat_messages_id_fkey");
        
        // new ChatsMessagesSeeder().Seed(builder);
    }
}