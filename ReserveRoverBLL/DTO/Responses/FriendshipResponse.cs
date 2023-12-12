namespace ReserveRoverBLL.DTO.Responses;

public class FriendshipResponse
{
    public int Id { get; set; }
    
    public string FriendId { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Avatar { get; set; }
}