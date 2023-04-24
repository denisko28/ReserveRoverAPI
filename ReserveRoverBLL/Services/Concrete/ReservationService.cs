using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Enums;
using ReserveRoverBLL.Helpers.Models;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class ReservationService : IReservationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReservationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReservationResponse>> GetReservationsByPlace(GetReservationsByPlaceRequest request,
        HttpContext httpContext)
    {
        // var managerId = UserClaimsHelper.GetUserId(httpContext);
        // var place = await _unitOfWork.PlacesRepository.GetByIdAsync(request.PlaceId);
        // if (place.ManagerId != managerId)
        //     throw new ForbiddenAccessException(
        //         $"You don't have access to the reservations of the place with id: {request.PlaceId}");

        var reservations = await _unitOfWork.ReservationsRepository.GetByPlaceAsync(request.PlaceId, request.FromTime,
            request.TillTime, request.PageNumber, request.PageSize);

        return reservations.Select(_mapper.Map<Reservation, ReservationResponse>);
    }

    public async Task<IEnumerable<ReservationResponse>> GetReservationsByUser(GetReservationsByUserRequest request,
        HttpContext httpContext)
    {
        var reservations = await _unitOfWork.ReservationsRepository.GetByUserAsync(request.UserId, request.FromTime,
            request.TillTime, request.PageNumber, request.PageSize);

        return reservations.Select(_mapper.Map<Reservation, ReservationResponse>);
    }

    public async Task<IEnumerable<PlaceTimeOfferResponse>> GetTimeOffers(GetTimeOffersRequest request)
    {
        if (request.Duration is < 1 or > 4)
            throw new Exception("Duration has to be from 1 to 4 hours");

        var timeOffers = new List<PlaceTimeOfferResponse>();
        var reservDate = JsonConvert.DeserializeObject<DateOnly>("\"" + request.ReservDate + "\"");
        var desiredTime = JsonConvert.DeserializeObject<TimeOnly>("\"" + request.DesiredTime + "\"");

        var place = await _unitOfWork.PlacesRepository.GetByIdAsync(request.PlaceId);
        if (desiredTime < place.OpensAt || desiredTime > place.ClosesAt.AddHours(-1))
            throw new Exception(
                $"Desired time should be in boundaries from {place.OpensAt} to {place.ClosesAt.AddHours(-1)}");

        var tableSets = await _unitOfWork.TableSetsRepository.GetByPlaceWithReservationsAsync(request.PlaceId);
        var tableSetsList = tableSets.ToList();

        foreach (var tableSet in tableSetsList)
        {
            if (tableSet.TableCapacity == request.PeopleNum && tableSet.TableCapacity > request.PeopleNum + 2)
                continue;

            var reservations = tableSet.Reservations.Where(r =>
                    r.ReservDate == reservDate &&
                    r.BeginTime >= desiredTime.AddHours(-6) &&
                    r.BeginTime < desiredTime.AddHours(2 + request.Duration))
                .ToList();

            var tables = TablesHelper.TablesReservationsFromTableSets(tableSet, reservations);

            var fromTime = desiredTime.AddHours(-2);
            var toTime = desiredTime.AddHours(2);
            for (TimeOnly beginTime = fromTime; beginTime <= toTime; beginTime = beginTime.AddMinutes(30))
            {
                var endTime = beginTime.AddHours(request.Duration);
                if (beginTime < place.OpensAt || endTime > place.ClosesAt.AddHours(-1))
                    continue;

                foreach (var table in tables)
                {
                    var hasFreeTime = table.HasTimeFor(new Reservation
                    {
                        ReservDate = reservDate, BeginTime = beginTime, EndTime = endTime
                    });
                    if (hasFreeTime)
                        timeOffers.Add(new PlaceTimeOfferResponse
                            {TableSetId = tableSet.Id, OfferedStartTime = beginTime, OfferedEndTime = endTime});
                }
            }
        }

        return timeOffers.Distinct().ToList();
    }

    public async Task<bool> CreateReservation(CreateReservationRequest request, HttpContext httpContext)
    {
        var tableSet = await _unitOfWork.TableSetsRepository.GetByIdWithReservationsAsync(request.TableSetId);
        var place = await _unitOfWork.PlacesRepository.GetByIdAsync(tableSet.PlaceId);
        if (request.EndTime - request.BeginTime < TimeSpan.FromHours(1) || request.BeginTime < place.OpensAt ||
            request.EndTime > place.ClosesAt)
            return false;
        // var userId = UserClaimsHelper.GetUserId(httpContext);
        // if (request.UserId == userId || place.ManagerId != userId)
        //     throw new ForbiddenAccessException(
        //         $"You can not add reservations for a different user if you are not manager of the place");

        if (tableSet.TableCapacity < request.PeopleNum && tableSet.TableCapacity > request.PeopleNum + 2)
            return false;

        var reservations = tableSet.Reservations.Where(r =>
                r.ReservDate == request.ReservDate &&
                r.BeginTime >= request.BeginTime.AddHours(-4) &&
                r.BeginTime < request.EndTime)
            .ToList();

        var tables = TablesHelper.TablesReservationsFromTableSets(tableSet, reservations);

        var success = false;

        var newReservation = _mapper.Map<CreateReservationRequest, Reservation>(request);
        newReservation.TableSetId = tableSet.Id;
        newReservation.PlaceId = tableSet.PlaceId;
        newReservation.Status = (short) ReservationStatus.Reserved;
        newReservation.CreationDateTime = DateTime.Now;

        foreach (var table in tables)
        {
            if (!table.HasTimeFor(newReservation))
                continue;

            await _unitOfWork.ReservationsRepository.InsertAsync(newReservation);
            success = true;
            break;
        }

        await _unitOfWork.SaveChangesAsync();
        return success;
    }
}