namespace ReserveRoverDAL.Entities;

public class Moderation
{
    public Guid Id { get; set; }

    public int PlaceId { get; set; }

    public string ModeratorId { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public short Status { get; set; }

    public virtual Place Place { get; set; } = null!;
}
