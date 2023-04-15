using AutoMapper;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverDAL.Entities;

namespace ReserveRoverBLL.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreatePlacesMaps();
        CreateLocationMaps();
    }

    private void CreatePlacesMaps()
    {
        CreateMap<Place, PlaceSearchResponse>();

        CreateMap<Place, PlaceDetailsResponse>()
            .ForMember(response => response.Description,
                options =>
                    options.MapFrom(place => place.PlaceDescription.Description))
            .ForMember(response => response.CityName,
                options =>
                    options.MapFrom(place => place.City.Name));
        CreateMap<AddPlaceRequest, Place>()
            .ForMember(place => place.Location, 
                option => option.Ignore())
            .ForMember(place => place.Tables, 
                option => option.Ignore());
    }

    private void CreateLocationMaps()
    {
        CreateMap<AddPlaceLocationRequest, Location>();
    }
}