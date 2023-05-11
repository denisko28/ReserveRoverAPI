namespace ReserveRoverBLL.DTO.Responses;

public class ReviewResponse
{
    public Guid Id { get; set; }

    public string AuthorPhotoUrl { get; set; } = null!;
    
    public string AuthorFullName { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public decimal Mark { get; set; }

    public string? Comment { get; set; }
}