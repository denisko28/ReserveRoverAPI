namespace ReserveRoverDAL.Entities;

public class ChatMessage
{
    public int Id { get; set; }
    
    public int ChatId { get; set; }

    public string FromUserId { get; set; } = null!;
    
    public string Message { get; set; } = null!;
    
    public DateTime DateTime { get; set; }
    
    public bool Viewed { get; set; }

    public virtual Chat Chat { get; set; } = null!;
}