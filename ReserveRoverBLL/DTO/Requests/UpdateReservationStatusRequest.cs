namespace ReserveRoverBLL.DTO.Requests;

public class UpdateReservationStatusRequest
{
    public string ReservationId { get; set; } = null!;

    public short NewStatus { get; set; }
}