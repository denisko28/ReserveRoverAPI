using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IPlacesService
{
    Task<IEnumerable<PlaceSearchResponse>> Search(PlaceSearchRequest request);

    Task<PlaceDetailsResponse> GetPlaceDetails(int placeId);

    Task<PlaceDetailsResponse> GetManagersPlace(string managerId);

    Task<string> UploadImage(IFormFile image, HttpContext httpContext);

    Task<int> CreatePlace(AddPlaceRequest placeRequest);
}