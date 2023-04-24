using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Exceptions;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class TableSetsRepository : GenericRepository<TableSet>, ITableSetsRepository
{
    public TableSetsRepository(ReserveRoverDbContext dBContext) : base(dBContext)
    {
    }

    public async Task<TableSet> GetByIdWithReservationsAsync(int id)
    {
        return await Table.Include(set => set.Reservations).FirstOrDefaultAsync(set => set.Id == id) ??
               throw new EntityNotFoundException(nameof(TableSet), id);
    }

    public async Task<IEnumerable<TableSet>> GetByPlaceWithReservationsAsync(int placeId)
    {
        return await Table
            .Include(set => set.Reservations)
            .Where(set => set.PlaceId == placeId)
            .OrderBy(set => set.TableCapacity)
            .ToListAsync();
    }

    public async Task InsertRangeAsync(IEnumerable<TableSet> tableSets)
    {
        await Table.AddRangeAsync(tableSets);
    }
}