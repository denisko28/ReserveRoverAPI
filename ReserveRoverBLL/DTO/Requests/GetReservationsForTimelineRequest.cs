namespace ReserveRoverBLL.DTO.Requests;

public class GetReservationsForTimelineRequest
{
    public int PlaceId { get; set; }

    public string TargetDate { get; set; } = null!;
}