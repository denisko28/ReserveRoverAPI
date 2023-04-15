using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class PlacesPaymentMethodsRepository : IPlacesPaymentMethodsRepository
{
    private readonly DbSet<PlacePaymentMethod> _placePaymentMethods;

    public PlacesPaymentMethodsRepository(ReserveRoverDbContext dbContext)
    {
        _placePaymentMethods = dbContext.Set<PlacePaymentMethod>();
    }

    public async Task<IEnumerable<PlacePaymentMethod>> GetByPlaceIdAsync(int placeId)
    {
        return await _placePaymentMethods.Where(p => p.PlaceId == placeId).ToListAsync();
    }

    public async Task InsertAsync(PlacePaymentMethod placePaymentMethod)
    {
        await _placePaymentMethods.AddAsync(placePaymentMethod);
    }
    
    public async Task InsertRangeAsync(IEnumerable<PlacePaymentMethod> placePaymentMethods)
    {
        await _placePaymentMethods.AddRangeAsync(placePaymentMethods);
    }

    public async Task DeleteAsync(PlacePaymentMethod placePaymentMethod)
    {
        await Task.Run(() => _placePaymentMethods.Remove(placePaymentMethod));
    }
}