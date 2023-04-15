using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IPlaceImagesRepository
{
    Task<IEnumerable<PlaceImage>> GetAsync(int placeId);

    Task Insert(PlaceImage placeImage);

    Task InsertRangeAsync(IEnumerable<PlaceImage> placeImages);

    Task UpdateAsync(PlaceImage placeImage);

    Task DeleteAsync(int placeId, short sequenceIndex);
}