namespace ReserveRoverDAL.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    
    public int PlaceId { get; set; } 

    public int TableSetId { get; set; }

    public string UserId { get; set; } = null!;

    public DateOnly ReservDate { get; set; }

    public TimeOnly BeginTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public short PeopleNum { get; set; }

    public short Status { get; set; }

    public DateTime CreationDateTime { get; set; }

    public virtual TableSet TableSet { get; set; } = null!;
}
