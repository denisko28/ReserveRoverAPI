using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IPlacesService
{
    Task<IEnumerable<PlaceSearchResponse>> Search(PlaceSearchRequest request);

    Task<PlaceDetailsResponse> GetPlaceDetails(int placeId);

    Task<IEnumerable<ReviewResponse>> GetPlaceReviews(GetPlaceReviewsRequest request);

    Task<PlaceDetailsResponse> GetManagersPlace(string managerId);

    Task<string> UploadImage(IFormFile image, HttpContext httpContext);

    Task SetImages(IEnumerable<string> imageUrls, HttpContext httpContext);

    Task<int> CreatePlace(AddPlaceRequest placeRequest, HttpContext httpContext);

    Task<IEnumerable<TableSetResponse>> GetPlaceTableSets(int placeId);
    
    Task<bool> SetPlaceTableSets(SetPlaceTableSetsRequest request);

    Task<ReviewResponse> CreateReview(CreatePlaceReviewRequest request, HttpContext httpContext);
}