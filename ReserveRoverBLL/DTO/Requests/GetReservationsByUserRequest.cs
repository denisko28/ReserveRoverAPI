namespace ReserveRoverBLL.DTO.Requests;

public class GetReservationsByUserRequest : BasePaginationRequest
{
    public string UserId { get; set; } = null!;
    
    public DateTime? FromTime { get; set; }
    
    public DateTime? TillTime { get; set; }
}