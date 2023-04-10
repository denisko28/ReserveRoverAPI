namespace ReserveRoverDAL.Entities;

public class PlacesDescription
{
    public int PlaceId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;
}
