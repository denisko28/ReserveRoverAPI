namespace ReserveRoverBLL.DTO.Requests;

public class GetModerationsRequest : BasePaginationRequest
{
    public int? PlaceId { get; set; }
    
    public string? ModeratorId { get; set; }
    
    public DateTime? FromTime { get; set; }
    
    public DateTime? TillTime { get; set; }
}