namespace ReserveRoverBLL.DTO.Requests;

public class CreatePlaceReviewRequest
{
    public int PlaceId { get; set; }

    public decimal Mark { get; set; }

    public string? Comment { get; set; }
}