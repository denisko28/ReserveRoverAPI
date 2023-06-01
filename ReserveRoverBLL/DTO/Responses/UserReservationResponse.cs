namespace ReserveRoverBLL.DTO.Responses;

public class UserReservationResponse
{
    public Guid Id { get; set; }

    public string PlaceImageUrl { get; set; } = null!;
    
    public string PlaceTitle { get; set; } = null!;
    
    public int PlaceId { get; set; } 

    public int TableSetId { get; set; }

    public string UserId { get; set; } = null!;

    public DateOnly ReservDate { get; set; }

    public TimeOnly BeginTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public short PeopleNum { get; set; }

    public short Status { get; set; }

    public DateTime CreationDateTime { get; set; }
}