namespace ReserveRoverDAL.Entities;

public class TableSet
{
    public int Id { get; set; }

    public int PlaceId { get; set; }

    public short TableCapacity { get; set; }

    public short TablesNum { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
