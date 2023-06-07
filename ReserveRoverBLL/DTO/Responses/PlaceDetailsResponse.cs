namespace ReserveRoverBLL.DTO.Responses;

public class PlaceDetailsResponse
{
    public int Id { get; set; }
    
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string MainImageUrl { get; set; } = null!;

    public string Title { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }

    public decimal? AvgMark { get; set; }

    public decimal AvgBill { get; set; }

    public string Address { get; set; } = null!;
    
    public DateTime SubmissionDateTime { get; set; }

    public DateOnly? PublicDate { get; set; }
    
    public short ModerationStatus { get; set; }

    public string Description { get; set; } = null!;
    
    public string[] ImageUrls { get; set; } = null!;
    
    public short[] PaymentMethods { get; set; } = null!;
}