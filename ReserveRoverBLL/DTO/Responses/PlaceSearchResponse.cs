namespace ReserveRoverBLL.DTO.Responses;

public class PlaceSearchResponse
{
    public int Id { get; set; }
    
    public string MainImageUrl { get; set; } = null!;

    public string Title { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }

    public decimal? AvgMark { get; set; }

    public decimal AvgBill { get; set; }
}