using AutoMapper;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Services.Abstract;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.UnitOfWork.Abstract;

namespace ReserveRoverBLL.Services.Concrete;

public class CitiesService : ICitiesService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public CitiesService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CityResponse>> GetAll()
    {
        var cities = await _unitOfWork.CitiesRepository.GetAllAsync();
        return cities.Select(_mapper.Map<City, CityResponse>);
    }
}