namespace ReserveRoverDAL.Entities;

public class Location
{
    public int PlaceId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual Place Place { get; set; } = null!;
}
