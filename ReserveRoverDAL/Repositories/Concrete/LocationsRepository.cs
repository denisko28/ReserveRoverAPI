using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class LocationsRepository : ILocationsRepository
{
    private readonly DbSet<Location> _locations;

    public LocationsRepository(ReserveRoverDbContext dbContext)
    {
        _locations = dbContext.Set<Location>();
    }

    public async Task<IEnumerable<Location>> GetAsync(int placeId)
    {
        return await _locations.Where(loc => loc.PlaceId == placeId).ToListAsync();
    }

    public async Task UpdateAsync(Location location)
    {
        await Task.Run(() => _locations.Update(location));
    }

    public async Task InsertAsync(Location location)
    {
        await _locations.AddAsync(location);
    }
}