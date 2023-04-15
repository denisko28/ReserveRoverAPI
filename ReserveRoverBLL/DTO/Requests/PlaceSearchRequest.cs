using ReserveRoverDAL.Enums;

namespace ReserveRoverBLL.DTO.Requests;

public class PlaceSearchRequest : BasePaginationRequest
{
    public int cityId { get; set; }
    public string? titleQuery { get; set; }
    public int sortOrder { get; set; }
}