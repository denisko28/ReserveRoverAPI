namespace ReserveRoverBLL.DTO.Responses;

public class PublicUserResponse
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public string? Avatar { get; set; }
}