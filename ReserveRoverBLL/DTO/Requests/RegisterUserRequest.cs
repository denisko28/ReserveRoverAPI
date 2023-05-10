namespace ReserveRoverBLL.DTO.Requests;

public class RegisterUserRequest
{
    public string Email { get; set; } = null!;
        
    public string Password { get; set; } = null!;
}