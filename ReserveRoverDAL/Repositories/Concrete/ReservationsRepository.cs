using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Exceptions;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class ReservationsRepository : IReservationsRepository
{
    private readonly DbSet<Reservation> _reservations;

    public ReservationsRepository(ReserveRoverDbContext dbContext)
    {
        _reservations = dbContext.Set<Reservation>();
    }

    public async Task<IEnumerable<Reservation>> GetByPlaceAsync(int placeId, DateTime? fromTime, DateTime? tillTime,
        int pageNumber, int pageSize)
    {
        var reservations = _reservations.Where(p => p.PlaceId == placeId);

        if (fromTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate > DateOnly.FromDateTime((DateTime) fromTime) ||
                (p.ReservDate == DateOnly.FromDateTime((DateTime) fromTime) &&
                 p.BeginTime >= TimeOnly.FromDateTime((DateTime) fromTime)));

        if (tillTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate < DateOnly.FromDateTime((DateTime) tillTime) ||
                (p.ReservDate == DateOnly.FromDateTime((DateTime) tillTime) &&
                 p.BeginTime < TimeOnly.FromDateTime((DateTime) tillTime)));

        return await reservations
            .OrderByDescending(p => p.ReservDate)
            .ThenByDescending(p => p.BeginTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetByUserAsync(string userId, DateTime? fromTime, DateTime? tillTime,
        int pageNumber, int pageSize)
    {
        var reservations = _reservations
            .Include(p => p.TableSet)
            .ThenInclude(tbs => tbs.Place)
            .Where(p => p.UserId == userId);

        if (fromTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate > DateOnly.FromDateTime((DateTime) fromTime) ||
                (p.ReservDate == DateOnly.FromDateTime((DateTime) fromTime) &&
                 p.BeginTime >= TimeOnly.FromDateTime((DateTime) fromTime)));

        if (tillTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate < DateOnly.FromDateTime((DateTime) tillTime) ||
                (p.ReservDate == DateOnly.FromDateTime((DateTime) tillTime) &&
                 p.BeginTime < TimeOnly.FromDateTime((DateTime) tillTime)));

        return await reservations
            .OrderByDescending(p => p.ReservDate)
            .ThenByDescending(p => p.BeginTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetByTableSetIdAndReservDateAsync(int tableSetId, DateOnly reservDate)
    {
        return await _reservations
            .Where(reservation => reservation.TableSetId == tableSetId && reservation.ReservDate == reservDate)
            .ToListAsync();
    }

    public async Task<int> CountTillDateByUserAsync(string userId, DateTime dateTime)
    {
        return await _reservations
            .Where(p => p.UserId == userId &&
                        p.ReservDate < DateOnly.FromDateTime(dateTime) ||
                        (p.ReservDate == DateOnly.FromDateTime(dateTime) &&
                         p.BeginTime < TimeOnly.FromDateTime(dateTime)))
            .CountAsync();
    }

    public async Task<int> CountFromDateByUserAsync(string userId, DateTime dateTime)
    {
        return await _reservations
            .Where(p => p.UserId == userId &&
                        p.ReservDate > DateOnly.FromDateTime(dateTime) ||
                        (p.ReservDate == DateOnly.FromDateTime(dateTime) &&
                         p.BeginTime >= TimeOnly.FromDateTime(dateTime)))
            .CountAsync();
    }

    public async Task InsertAsync(Reservation reservation)
    {
        await _reservations.AddAsync(reservation);
    }

    public async Task UpdateStatusAsync(string id, short status)
    {
        var entity = await _reservations.FirstOrDefaultAsync(u => u.Id.ToString() == id)
                     ?? throw new EntityNotFoundException(nameof(Reservation), id);

        entity.Status = status;
    }
}