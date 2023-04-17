using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class ModerationRepository : IModerationRepository
{
    private readonly DbSet<Moderation> _moderations;

    public ModerationRepository(ReserveRoverDbContext dbContext)
    {
        _moderations = dbContext.Set<Moderation>();
    }

    public async Task<IEnumerable<Moderation>> GetAsync(int? placeId, string? moderatorId, DateTime? fromTime, DateTime? tillTime, int pageNumber, int pageSize)
    {
        var moderations = _moderations.AsQueryable();

        if (placeId != null)
            moderations = moderations.Where(p => p.PlaceId == placeId);
        
        if (moderatorId != null)
            moderations = moderations.Where(p => p.ModeratorId == moderatorId);

        if (fromTime != null)
            moderations = moderations.Where(p => p.DateTime >= fromTime);

        if (tillTime != null)
            moderations = moderations.Where(p => p.DateTime <= tillTime);

        return await moderations.OrderBy(p => p.DateTime).Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task InsertAsync(Moderation moderation)
    {
        await _moderations.AddAsync(moderation);
    }
}