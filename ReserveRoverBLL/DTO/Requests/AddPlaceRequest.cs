namespace ReserveRoverBLL.DTO.Requests;

public class AddPlaceRequest
{
    public int CityId { get; set; }
    
    public string MainImageUrl { get; set; } = null!;

    public string Title { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }

    public decimal AvgBill { get; set; }

    public string Address { get; set; } = null!;

    public string Description { get; set; } = null!;
    
    public short[] PaymentMethods { get; set; } = null!;
    
    public string[] ImageUrls { get; set; } = null!;

    public AddPlaceLocationRequest? Location { get; set; }
}