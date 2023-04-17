using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IModerationRepository
{
    Task<IEnumerable<Moderation>> GetAsync(int? placeId, string? moderatorId, DateTime? fromTime, DateTime? tillTime, int pageNumber,
        int pageSize);

    Task InsertAsync(Moderation moderation);
}