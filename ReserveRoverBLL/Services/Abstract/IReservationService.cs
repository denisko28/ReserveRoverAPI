using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface IReservationService
{
    Task<IEnumerable<ReservationResponse>> GetReservationsByPlace(GetReservationsByPlaceRequest request,
        HttpContext httpContext);

    Task<IEnumerable<ReservationResponse>> GetReservationsByUser(GetReservationsByUserRequest request,
        HttpContext httpContext);

    Task<IEnumerable<PlaceTimeOfferResponse>> GetTimeOffers(GetTimeOffersRequest request);

    Task<bool> CreateReservation(CreateReservationRequest request, HttpContext httpContext);
}