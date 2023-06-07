using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Exceptions;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class TableSetsRepository: ITableSetsRepository
{
    private readonly DbSet<TableSet> _tableSets;

    public TableSetsRepository(ReserveRoverDbContext dbContext)
    {
        _tableSets = dbContext.Set<TableSet>();
    }

    public async Task<TableSet> GetByIdWithReservationsAsync(int id)
    {
        return await _tableSets.Include(set => set.Reservations).FirstOrDefaultAsync(set => set.Id == id) ??
               throw new EntityNotFoundException(nameof(TableSet), id);
    }

    public async Task<IEnumerable<TableSet>> GetByPlaceAsync(int placeId)
    {
        return await _tableSets
            .Where(set => set.PlaceId == placeId)
            .OrderBy(set => set.TableCapacity)
            .ToListAsync();
    }

    public async Task InsertRangeAsync(IEnumerable<TableSet> tableSets)
    {
        await _tableSets.AddRangeAsync(tableSets);
    }
    
    public async Task UpdateRangeAsync(IEnumerable<TableSet> tableSets)
    {
        await Task.Run(() => _tableSets.UpdateRange(tableSets));
    }
    
    public async Task DeleteByIdRangeAsync(IEnumerable<int> ids)
    {
        var tableSets = _tableSets.Where(tableSet => ids.Contains(tableSet.Id));
        await Task.Run(() => _tableSets.RemoveRange(tableSets));
    }
}