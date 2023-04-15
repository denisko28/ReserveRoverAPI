using AutoMapper;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Enums;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class PlacesService : IPlacesService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlacesService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlaceSearchResponse>> Search(int cityId, string? titleQuery, int sortOrder,
        int pageNumber, int pageSize)
    {
        var result = await _unitOfWork.PlacesRepository.GetAsync(cityId, titleQuery,
            (short) ModerationStatus.Approved,
            (PlacesSortOrder) sortOrder, pageNumber, pageSize);

        return result.Select(_mapper.Map<Place, PlaceSearchResponse>);
    }

    private async Task<PlaceDetailsResponse> PlaceToPlaceDetails(Place place)
    {
        var response = _mapper.Map<Place, PlaceDetailsResponse>(place);

        var images = await _unitOfWork.PlaceImagesRepository.GetAsync(place.Id);
        response.ImageUrls = images.Select(i => i.ImageUrl).ToArray();

        var paymentMethods = await _unitOfWork.PlacesPaymentMethodsRepository.GetByPlaceIdAsync(place.Id);
        response.PaymentMethods = paymentMethods.Select(pm => pm.Method).ToArray();

        return response;
    }

    public async Task<PlaceDetailsResponse> GetPlaceDetails(int placeId)
    {
        var place = await _unitOfWork.PlacesRepository.GetByIdAsync(placeId);
        return await PlaceToPlaceDetails(place);
    }

    public async Task<PlaceDetailsResponse> GetManagersPlace(string managerId)
    {
        var place = await _unitOfWork.PlacesRepository.GetByManagerAsync(managerId);
        return await PlaceToPlaceDetails(place);
    }

    public async Task<int> CreatePlace(AddPlaceRequest placeRequest)
    {
        var place = _mapper.Map<AddPlaceRequest, Place>(placeRequest);
        place.ImagesCount = (short) placeRequest.ImageUrls.Length;
        await using var transaction = await _unitOfWork.DbContext.Database.BeginTransactionAsync();
        try
        {
            await _unitOfWork.PlacesRepository.InsertAsync(place);
            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.PlacesRepository.AddDescription(new PlaceDescription
                {PlaceId = place.Id, Description = placeRequest.Description});

            await _unitOfWork.PlacesPaymentMethodsRepository.InsertRangeAsync(
                placeRequest.PaymentMethods.Select(method =>
                    new PlacePaymentMethod {PlaceId = place.Id, Method = method}));

            await _unitOfWork.PlaceImagesRepository.InsertRangeAsync(
                placeRequest.ImageUrls.Select((url, index) =>
                    new PlaceImage {PlaceId = place.Id, ImageUrl = url, SequenceIndex = (short) index}));

            if (placeRequest.Location != null)
            {
                var location = _mapper.Map<AddPlaceLocationRequest, Location>(placeRequest.Location);
                location.PlaceId = place.Id;
                await _unitOfWork.LocationsRepository.InsertAsync(location);
            }

            var tables = placeRequest.Tables.Select(table => new Table
                {PlaceId = place.Id, TableCapacity = table.TableCapacity, TablesNum = table.TablesNum});
            await _unitOfWork.TablesRepository.InsertRangeAsync(tables);

            await _unitOfWork.SaveChangesAsync();
            await transaction.CommitAsync();
            return place.Id;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}