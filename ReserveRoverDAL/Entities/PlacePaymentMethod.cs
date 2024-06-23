namespace ReserveRoverDAL.Entities;

public class PlacePaymentMethod
{
    public int PlaceId { get; set; }

    public short Method { get; set; }

    public virtual Place Place { get; set; } = null!;
}
