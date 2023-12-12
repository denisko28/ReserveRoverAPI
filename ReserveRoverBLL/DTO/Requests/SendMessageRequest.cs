namespace ReserveRoverBLL.DTO.Requests;

public class SendMessageRequest
{
    public string ToUserId { get; set; } = null!;

    public string Message { get; set; } = null!;
}