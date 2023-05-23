using ReserveRoverDAL.Entities;

namespace ReserveRoverDAL.Repositories.Abstract;

public interface ICitiesRepository
{
    Task<IEnumerable<City>> GetAllAsync();
}