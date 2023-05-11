using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IPlaceImagesRepository
{
    Task<IEnumerable<PlaceImage>> GetAsync(int placeId);

    Task InsertAsync(PlaceImage placeImage);

    Task InsertRangeAsync(IEnumerable<PlaceImage> placeImages);

    Task DeleteByPlaceAsync(int placeId);
}