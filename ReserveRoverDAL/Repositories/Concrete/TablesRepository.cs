using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class TablesRepository : GenericRepository<Table>, ITablesRepository
{
    public TablesRepository(ReserveRoverDbContext dBContext) : base(dBContext)
    {
    }

    public async Task InsertRangeAsync(IEnumerable<Table> tables)
    {
        await Table.AddRangeAsync(tables);
    }
}