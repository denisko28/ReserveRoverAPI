namespace ReserveRoverBLL.DTO.Responses;

public class ModerationResponse
{
    public Guid Id { get; set; }

    public int PlaceId { get; set; }

    public string ModeratorId { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public short Status { get; set; }
}