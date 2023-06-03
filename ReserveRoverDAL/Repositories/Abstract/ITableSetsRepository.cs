using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ITableSetsRepository : IGenericRepository<TableSet>
{
    Task<TableSet> GetByIdWithReservationsAsync(int id);
    
    Task<IEnumerable<TableSet>> GetByPlaceAsync(int placeId);
    
    Task InsertRangeAsync(IEnumerable<TableSet> tableSets);

    Task UpdateRangeAsync(IEnumerable<TableSet> tableSets);
}