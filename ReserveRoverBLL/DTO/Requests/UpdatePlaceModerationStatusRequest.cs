namespace ReserveRoverBLL.DTO.Requests;

public class UpdatePlaceModerationStatusRequest
{
    public int PlaceId { get; set; }
    public short ModerationStatus { get; set; }
}