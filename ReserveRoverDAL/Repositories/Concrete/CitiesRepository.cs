using Microsoft.EntityFrameworkCore;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Repositories.Abstract;

namespace ReserveRoverDAL.Repositories.Concrete;

public class CitiesRepository : ICitiesRepository
{
    private readonly DbSet<City> _cities;

    public CitiesRepository(ReserveRoverDbContext dbContext)
    {
        _cities = dbContext.Set<City>();
    }
    
    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _cities.ToListAsync();
    }
}