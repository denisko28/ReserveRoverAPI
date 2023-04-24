using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Extensions;
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
                p.ReservDate >= DateOnly.FromDateTime((DateTime) fromTime) &&
                p.BeginTime >= TimeOnly.FromDateTime((DateTime) fromTime));

        if (tillTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate <= DateOnly.FromDateTime((DateTime)tillTime) && 
                p.EndTime <= TimeOnly.FromDateTime((DateTime) tillTime));

        return await reservations.OrderBy(p => p.ReservDate).ThenBy(p => p.BeginTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetByUserAsync(string userId, DateTime? fromTime, DateTime? tillTime,
        int pageNumber, int pageSize)
    {
        var reservations = _reservations.Where(p => p.UserId == userId);

        if (fromTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate >= DateOnly.FromDateTime((DateTime) fromTime) &&
                p.BeginTime >= TimeOnly.FromDateTime((DateTime) fromTime));

        if (tillTime != null)
            reservations = reservations.Where(p =>
                p.ReservDate <= DateOnly.FromDateTime((DateTime)tillTime) && 
                p.EndTime <= TimeOnly.FromDateTime((DateTime) tillTime));

        return await reservations.OrderBy(p => p.ReservDate).ThenBy(p => p.BeginTime)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task InsertAsync(Reservation reservation)
    {
        await _reservations.AddAsync(reservation);
    }
}