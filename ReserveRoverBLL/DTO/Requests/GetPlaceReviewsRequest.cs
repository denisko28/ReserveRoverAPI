namespace ReserveRoverBLL.DTO.Requests;

public class GetPlaceReviewsRequest : BasePaginationRequest
{
    public int PlaceId { get; set; }
}