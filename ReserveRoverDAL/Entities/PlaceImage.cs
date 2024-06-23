namespace ReserveRoverDAL.Entities;

public class PlaceImage
{
    public int PlaceId { get; set; }

    public short SequenceIndex { get; set; }

    public string ImageUrl { get; set; } = null!;

    public virtual Place Place { get; set; } = null!;
}
