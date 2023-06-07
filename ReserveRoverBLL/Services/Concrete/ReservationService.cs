using System.ComponentModel;
using AutoMapper;
using FirebaseAdmin.Auth;
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
    private readonly IIdentityService _identityService;

    public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<IEnumerable<TimelineReservationResponse>> GetReservationsForTimeline(
        GetReservationsForTimelineRequest request, HttpContext httpContext)
    {
        // var managerId = UserClaimsHelper.GetUserId(httpContext);
        // var place = await _unitOfWork.PlacesRepository.GetByIdAsync(request.PlaceId);
        // if (place.ManagerId != managerId)
        //     throw new ForbiddenAccessException(
        //         $"You don't have access to the reservations of the place with id: {request.PlaceId}");

        var targetDate = JsonConvert.DeserializeObject<DateOnly>("\"" + request.TargetDate + "\"");
        var tableSets = await _unitOfWork.TableSetsRepository.GetByPlaceAsync(request.PlaceId);

        var results = new List<TimelineReservationResponse>();
        var userIdentifiers = new List<UidIdentifier>();
        foreach (var tableSet in tableSets)
        {
            var reservations =
                await _unitOfWork.ReservationsRepository.GetByTableSetIdAndReservDateAsync(tableSet.Id, targetDate);
            var tables = TablesHelper.TablesReservationsFromTableSets(tableSet, reservations.ToList());
            foreach (var table in tables)
            {
                var tableReservations = new List<TimelineReservationResponse.TableReservation>();
                foreach (var reservation in table.Reservations)
                {
                    userIdentifiers.Add(new UidIdentifier(reservation.UserId));
                    tableReservations.Add(new TimelineReservationResponse.TableReservation
                    {
                        Id = reservation.Id.ToString(),
                        UserId = reservation.UserId,
                        BeginTime = reservation.ReservDate.ToDateTime(reservation.BeginTime),
                        EndTime = reservation.ReservDate.ToDateTime(reservation.EndTime)
                    });
                }
                results.Add(new TimelineReservationResponse
                {
                    TableCapacity = table.Capacity,
                    TableReservations = tableReservations
                });
            }
            
        }
        
        var usersResult = await _identityService.GetUsersById(userIdentifiers);
        var users = usersResult.Users.ToDictionary(user => user.Uid, user => user);
        foreach (var reservation in results.SelectMany(result => result.TableReservations))
        {
            reservation.UserName = users[reservation.UserId].DisplayName;
        }
        
        return results;
    }

    public async Task<IEnumerable<PlaceReservationResponse>> GetReservationsByPlace(
        GetReservationsByPlaceRequest request,
        HttpContext httpContext)
    {
        // var managerId = UserClaimsHelper.GetUserId(httpContext);
        // var place = await _unitOfWork.PlacesRepository.GetByIdAsync(request.PlaceId);
        // if (place.ManagerId != managerId)
        //     throw new ForbiddenAccessException(
        //         $"You don't have access to the reservations of the place with id: {request.PlaceId}");

        var reservations = await _unitOfWork.ReservationsRepository.GetByPlaceAsync(request.PlaceId, request.FromTime,
            request.TillTime, request.PageNumber, request.PageSize);

        return reservations.Select(_mapper.Map<Reservation, PlaceReservationResponse>);
    }

    public async Task<IEnumerable<UserReservationResponse>> GetReservationsByUser(GetReservationsByUserRequest request,
        HttpContext httpContext)
    {
        var reservations = await _unitOfWork.ReservationsRepository.GetByUserAsync(request.UserId, request.FromTime,
            request.TillTime, request.PageNumber, request.PageSize);

        return reservations.Select(_mapper.Map<Reservation, UserReservationResponse>);
    }

    public async Task<ReservationsCountResponse> GetReservationsCountByUser(GetReservationsCountByUserRequest request,
        HttpContext httpContext)
    {
        var futureCount =
            await _unitOfWork.ReservationsRepository.CountFromDateByUserAsync(request.UserId, request.DateTime);
        var pastCount =
            await _unitOfWork.ReservationsRepository.CountTillDateByUserAsync(request.UserId, request.DateTime);
        var total = futureCount + pastCount;
        return new ReservationsCountResponse {TotalCount = total, FutureCount = futureCount, PastCount = pastCount};
    }

    private static bool IsWithinBoundaries(TimeOnly startTime, TimeOnly endTime, TimeOnly intervalStartTime,
        TimeOnly intervalEndTime)
    {
        if (intervalEndTime > intervalStartTime)
        {
            return intervalStartTime >= startTime && intervalEndTime <= endTime;
        }

        return intervalEndTime >= startTime && intervalStartTime <= endTime;
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

        var tableSets = await _unitOfWork.TableSetsRepository.GetByPlaceAsync(request.PlaceId);

        foreach (var tableSet in tableSets)
        {
            if (tableSet.TableCapacity < request.PeopleNum || tableSet.TableCapacity > request.PeopleNum + 2)
                continue;

            var reservations =
                await _unitOfWork.ReservationsRepository.GetByTableSetIdAndReservDateAsync(tableSet.Id, reservDate);
            reservations = reservations.Where(r =>
                r.BeginTime >= desiredTime.AddHours(-6) &&
                r.BeginTime < desiredTime.AddHours(2 + request.Duration));

            var tables = TablesHelper.TablesReservationsFromTableSets(tableSet, reservations.ToList());

            var fromTime = desiredTime.AddHours(-2);
            var toTime = desiredTime.AddHours(2);
            for (TimeOnly beginTime = fromTime; beginTime <= toTime; beginTime = beginTime.AddMinutes(30))
            {
                var endTime = beginTime.AddHours(request.Duration);

                if (!IsWithinBoundaries(place.OpensAt, place.ClosesAt, beginTime, endTime))
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

    public async Task UpdateReservationStatus(UpdateReservationStatusRequest request, HttpContext httpContext)
    {
        if (!Enum.IsDefined(typeof(ReservationStatus), (int) request.NewStatus))
            throw new InvalidEnumArgumentException("Passed newStatus argument is out enumerated values!");

        await _unitOfWork.ReservationsRepository.UpdateStatusAsync(request.ReservationId, request.NewStatus);
        await _unitOfWork.SaveChangesAsync();
    }
}