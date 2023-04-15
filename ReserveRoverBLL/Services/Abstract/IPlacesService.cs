using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IPlacesService
{
    Task<IEnumerable<PlaceSearchResponse>> Search(int cityId, string? titleQuery, int sortOrder,
        int pageNumber, int pageSize);

    Task<PlaceDetailsResponse> GetPlaceDetails(int placeId);

    Task<PlaceDetailsResponse> GetManagersPlace(string managerId);

    Task<int> CreatePlace(AddPlaceRequest placeRequest);
}