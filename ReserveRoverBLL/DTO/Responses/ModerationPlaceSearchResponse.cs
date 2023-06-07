namespace ReserveRoverBLL.DTO.Responses;

public class ModerationPlaceSearchResponse
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    
    public string ManagerId { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public short ImagesCount { get; set; }
    
    public DateTime SubmissionDateTime { get; set; }

    public DateOnly? PublicDate { get; set; }
}