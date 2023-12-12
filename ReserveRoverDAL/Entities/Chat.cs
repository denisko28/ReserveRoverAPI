namespace ReserveRoverDAL.Entities;

public class Chat
{
    public int Id { get; set; }
    
    public string User1Id { get; set; } = null!;

    public string User2Id { get; set; } = null!;
    
    public virtual PublicUser User1 { get; set; } = null!;
    
    public virtual PublicUser User2 { get; set; } = null!;

    public virtual IEnumerable<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
}