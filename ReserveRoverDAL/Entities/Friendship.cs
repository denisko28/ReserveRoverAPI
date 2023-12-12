namespace ReserveRoverDAL.Entities;

public class Friendship
{
    public int Id { get; set; }

    public string User1Id { get; set; } = null!;
    
    public string User2Id { get; set; } = null!;
    
    public DateTime RequestedDateTime { get; set; }
    
    public bool Accepted { get; set; }
    
    public virtual PublicUser User1 { get; set; } = null!;
    
    public virtual PublicUser User2 { get; set; } = null!;
}
