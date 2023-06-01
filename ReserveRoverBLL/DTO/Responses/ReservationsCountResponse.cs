namespace ReserveRoverBLL.DTO.Responses;

public class ReservationsCountResponse
{
    public int TotalCount { get; set; }
    
    public int FutureCount { get; set; }
    
    public int PastCount { get; set; }
}