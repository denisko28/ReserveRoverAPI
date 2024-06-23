namespace ReserveRoverDAL.Entities;

public class PlaceDescription
{
    public int PlaceId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;
}
