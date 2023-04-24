namespace ReserveRoverBLL.DTO.Requests;

public class GetTimeOffersRequest
{
    public int PlaceId { get; set; }
    
    public string ReservDate { get; set; } = null!;

    public string DesiredTime { get; set; } = null!;

    public short Duration { get; set; }

    public short PeopleNum { get; set; }
}