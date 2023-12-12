namespace ReserveRoverBLL.DTO.Requests;

public class SearchForFriendsRequest : BasePaginationRequest
{
    public string? searchQuery { get; set; }
}