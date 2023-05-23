using ReserveRoverBLL.DTO.Responses;

namespace ReserveRoverBLL.Services.Abstract;

public interface ICitiesService
{
    Task<IEnumerable<CityResponse>> GetAll();
}