using AutoMapper;
using Microsoft.AspNetCore.Http;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Enums;
using ReserveRoverBLL.Helpers;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class ModerationService : IModerationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ModerationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ModerationResponse>> ModerationsSearch(GetModerationsRequest request)
    {
        var result = await _unitOfWork.ModerationRepository.GetAsync(request.PlaceId, request.ModeratorId, request.FromTime,
            request.TillTime, request.PageNumber, request.PageSize);

        return result.Select(_mapper.Map<Moderation, ModerationResponse>);
    }

    public async Task<IEnumerable<ModerationPlaceSearchResponse>> PlacesSearch(ModerationPlaceSearchRequest request)
    {
        var result = await _unitOfWork.PlacesRepository.GetByModerationStatusAsync(request.TitleQuery,
            request.ModerationStatus, request.FromTime, request.TillTime, request.PageNumber, request.PageSize);

        return result.Select(_mapper.Map<Place, ModerationPlaceSearchResponse>);
    }

    public async Task UpdateModerationStatus(UpdatePlaceModerationStatusRequest request, HttpContext httpContext)
    {
        var moderatorId = UserClaimsHelper.GetUserId(httpContext);
        var place = await _unitOfWork.PlacesRepository.GetByIdAsync(request.PlaceId);

        place.ModerationStatus = request.ModerationStatus;
        if ((ModerationStatus) request.ModerationStatus == ModerationStatus.Approved)
            place.PublicDate = DateOnly.FromDateTime(DateTime.Now);
        else
            place.PublicDate = null;

        await _unitOfWork.PlacesRepository.UpdateAsync(place);

        var moderation = new Moderation
        {
            PlaceId = request.PlaceId,
            ModeratorId = moderatorId,
            DateTime = DateTime.Now,
            Status = request.ModerationStatus
        };
        await _unitOfWork.ModerationRepository.InsertAsync(moderation);

        await _unitOfWork.SaveChangesAsync();
    }
}