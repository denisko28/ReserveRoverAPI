using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IReservationService
{
    Task<IEnumerable<TimelineReservationResponse>> GetReservationsForTimeline(GetReservationsForTimelineRequest request,
        HttpContext httpContext);

    Task<IEnumerable<PlaceReservationResponse>> GetReservationsByPlace(GetReservationsByPlaceRequest request,
        HttpContext httpContext);

    Task<IEnumerable<UserReservationResponse>> GetReservationsByUser(GetReservationsByUserRequest request,
        HttpContext httpContext);

    Task<ReservationsCountResponse> GetReservationsCountByUser(GetReservationsCountByUserRequest request,
        HttpContext httpContext);

    Task<IEnumerable<PlaceTimeOfferResponse>> GetTimeOffers(GetTimeOffersRequest request);

    Task<bool> CreateReservation(CreateReservationRequest request, HttpContext httpContext);

    Task UpdateReservationStatus(UpdateReservationStatusRequest request, HttpContext httpContext);
}