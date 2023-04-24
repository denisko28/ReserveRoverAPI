using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ITableSetsRepository : IGenericRepository<TableSet>
{
    Task<TableSet> GetByIdWithReservationsAsync(int id);
    
    Task<IEnumerable<TableSet>> GetByPlaceWithReservationsAsync(int placeId);
    
    Task InsertRangeAsync(IEnumerable<TableSet> tableSets);
}