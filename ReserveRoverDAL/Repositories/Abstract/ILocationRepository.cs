using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ILocationsRepository
{
    Task<IEnumerable<Location>> GetAsync(int placeId);
    
    Task UpdateAsync(Location location);

    Task InsertAsync(Location location);
}