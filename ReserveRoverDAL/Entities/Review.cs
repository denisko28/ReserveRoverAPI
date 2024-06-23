namespace ReserveRoverDAL.Entities;

public class Review
{
    public Guid Id { get; set; }

    public int PlaceId { get; set; }

    public string AuthorId { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public decimal Mark { get; set; }

    public string? Comment { get; set; }

    public virtual Place Place { get; set; } = null!;
}
