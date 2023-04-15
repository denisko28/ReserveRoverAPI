using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Enums;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ITablesRepository : IGenericRepository<Table>
{
    Task InsertRangeAsync(IEnumerable<Table> tables);
}