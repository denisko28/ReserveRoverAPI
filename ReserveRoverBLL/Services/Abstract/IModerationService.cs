using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IModerationService
{
    Task<IEnumerable<ModerationResponse>> ModerationsSearch(GetModerationsRequest request);
    
    Task<IEnumerable<ModerationPlaceSearchResponse>> PlacesSearch(ModerationPlaceSearchRequest request);

    Task UpdateModerationStatus(UpdatePlaceModerationStatusRequest request, HttpContext httpContext);
}