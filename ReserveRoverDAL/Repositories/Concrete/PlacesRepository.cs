using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;
using ReserveRoverDAL.Exceptions;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class PlacesRepository : GenericRepository<Place>, IPlacesRepository
{
    private readonly DbSet<PlaceDescription> _placeDescriptions;

    public PlacesRepository(ReserveRoverDbContext dBContext) : base(dBContext)
    {
        _placeDescriptions = DbContext.Set<PlaceDescription>();
    }

    public async Task<IEnumerable<Place>> GetAsync(int cityId, string? titleQuery, int? moderationStatus,
        PlacesSortOrder sortOrder, int pageNumber, int pageSize)
    {
        var places = Table.Where(p => p.CityId == cityId);

        if (moderationStatus != null)
            places = places.Where(p => p.ModerationStatus == moderationStatus);

        if (!string.IsNullOrEmpty(titleQuery))
            places = places.Where(p => p.SearchVector.Matches(EF.Functions.ToTsQuery(titleQuery + ":*")));

        switch (sortOrder)
        {
            case PlacesSortOrder.NewestDesc:
                places = places.OrderByDescending(p => p.PublicDate);
                break;
            case PlacesSortOrder.PopularityDesc:
                places = places.OrderByDescending(p => p.Popularity);
                break;
            case PlacesSortOrder.AvgMarkDesc:
                places = places.OrderByDescending(p => p.AvgMark);
                break;
        }

        return await places.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Place>> GetByModerationStatusAsync(string? titleQuery, int moderationStatus,
        DateTime? fromTime, DateTime? tillTime, int pageNumber, int pageSize)
    {
        var places = Table
            .Include(place => place.City)
            .Where(p => p.ModerationStatus == moderationStatus);

        if (!string.IsNullOrEmpty(titleQuery))
            places = places.Where(p => p.SearchVector.Matches(EF.Functions.ToTsQuery(titleQuery + ":*")));

        if (fromTime != null)
            places = places.Where(p => p.SubmissionDateTime >= fromTime);

        if (tillTime != null)
            places = places.Where(p => p.SubmissionDateTime <= tillTime);

        return await places.OrderBy(p => p.SubmissionDateTime).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public override async Task<Place> GetByIdAsync(int id)
    {
        return await Table
                   .Include(place => place.PlaceDescription)
                   .Include(place => place.City)
                   .SingleOrDefaultAsync(place => place.Id == id)
               ?? throw new EntityNotFoundException(nameof(Place), id);
    }

    public async Task<Place> GetByManagerAsync(string managerId)
    {
        return await Table
                   .Include(place => place.PlaceDescription)
                   .Include(place => place.City)
                   .SingleOrDefaultAsync(place => place.ManagerId == managerId)
               ?? throw new EntityNotFoundException(nameof(Place), "managerId:" + managerId);
    }

    public async Task AddDescription(PlaceDescription placeDescription)
    {
        await _placeDescriptions.AddAsync(placeDescription);
    }
}