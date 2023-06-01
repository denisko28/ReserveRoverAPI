namespace ReserveRoverBLL.DTO.Requests;

public class GetReservationsCountByUserRequest
{
    public string UserId { get; set; } = null!;
    
    public DateTime DateTime { get; set; }
}