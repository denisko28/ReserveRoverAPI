using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface IReservationsRepository
{
    Task<IEnumerable<Reservation>> GetByPlaceAsync(int placeId, DateTime? fromTime, DateTime? tillTime, int pageNumber, int pageSize);

    Task<IEnumerable<Reservation>> GetByUserAsync(string userId, DateTime? fromTime, DateTime? tillTime, int pageNumber, int pageSize);

    Task InsertAsync(Reservation reservation);
}