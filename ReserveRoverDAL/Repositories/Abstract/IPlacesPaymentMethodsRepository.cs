using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IPlacesPaymentMethodsRepository
{
    Task<IEnumerable<PlacePaymentMethod>> GetByPlaceIdAsync(int placeId);

    Task InsertAsync(PlacePaymentMethod place);

    Task InsertRangeAsync(IEnumerable<PlacePaymentMethod> placePaymentMethods);

    Task DeleteAsync(PlacePaymentMethod place);
}