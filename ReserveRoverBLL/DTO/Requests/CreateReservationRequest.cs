namespace ReserveRoverBLL.DTO.Requests;

public class CreateReservationRequest
{
    public int TableSetId { get; set; }
    
    public string UserId { get; set; } = null!;

    public DateOnly ReservDate { get; set; }

    public TimeOnly BeginTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public short PeopleNum { get; set; }
}