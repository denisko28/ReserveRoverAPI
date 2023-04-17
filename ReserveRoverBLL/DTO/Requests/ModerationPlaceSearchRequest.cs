namespace ReserveRoverBLL.DTO.Requests;

public class ModerationPlaceSearchRequest : BasePaginationRequest
{
    public string? TitleQuery { get; set; }
    
    public int ModerationStatus { get; set; }
    
    public DateTime? FromTime { get; set; }
    
    public DateTime? TillTime { get; set; }
}