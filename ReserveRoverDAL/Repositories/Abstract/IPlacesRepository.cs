using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IPlacesRepository : IGenericRepository<Place>
{
    Task<IEnumerable<Place>> GetAsync(int cityId, string? titleQuery, int? moderationStatus,
        PlacesSortOrder sortOrder, int pageNumber, int pageSize);

    Task<IEnumerable<Place>> GetByModerationStatusAsync(string? titleQuery, int moderationStatus, DateTime? fromTime,
        DateTime? tillTime, int pageNumber, int pageSize);

    Task<Place> GetByManagerAsync(string managerId);

    Task AddDescription(PlaceDescription placeDescription);
}