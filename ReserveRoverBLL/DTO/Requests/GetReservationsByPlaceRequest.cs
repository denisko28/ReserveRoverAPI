namespace ReserveRoverBLL.DTO.Requests;

public class GetReservationsByPlaceRequest : BasePaginationRequest
{
    public int PlaceId { get; set; }
    
    public DateTime? FromTime { get; set; }
    
    public DateTime? TillTime { get; set; }
}