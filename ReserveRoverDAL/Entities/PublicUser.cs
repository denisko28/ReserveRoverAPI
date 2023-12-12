namespace ReserveRoverDAL.Entities;

public class PublicUser
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Avatar { get; set; }

    public virtual IEnumerable<Friendship> FriendshipsUser1 { get; set; } = new List<Friendship>();
    
    public virtual IEnumerable<Friendship> FriendshipsUser2 { get; set; } = new List<Friendship>();
    
    public virtual IEnumerable<Chat> ChatsUser1 { get; set; } = new List<Chat>();
    
    public virtual IEnumerable<Chat> ChatsUser2 { get; set; } = new List<Chat>();
}
