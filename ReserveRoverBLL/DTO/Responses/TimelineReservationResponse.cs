namespace ReserveRoverBLL.DTO.Responses;

public class TimelineReservationResponse
{
    public int TableCapacity { get; set; }

    public IEnumerable<TableReservation> TableReservations { get; set; }
    
    public class TableReservation
    {
        public string Id { get; set; } = null!;

        public string UserId { get; set; } = null!;
        
        public string UserName { get; set; } = null!;
        
        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}