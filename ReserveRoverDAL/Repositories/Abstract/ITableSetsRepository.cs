using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ITableSetsRepository
{
    Task<TableSet> GetByIdWithReservationsAsync(int id);
    
    Task<IEnumerable<TableSet>> GetByPlaceAsync(int placeId);
    
    Task InsertRangeAsync(IEnumerable<TableSet> tableSets);

    Task UpdateRangeAsync(IEnumerable<TableSet> tableSets);
    
    Task DeleteByIdRangeAsync(IEnumerable<int> ids);
}