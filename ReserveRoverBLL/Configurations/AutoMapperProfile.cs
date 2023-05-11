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
        CreateReviewsMaps();
        CreateReservationMaps();
        CreateModerationMaps();
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
            .ForMember(place => place.TableSets, 
                option => option.Ignore());
    }

    private void CreateReviewsMaps()
    {
        CreateMap<CreatePlaceReviewRequest, Review>();
        CreateMap<Review, ReviewResponse>();
    }

    private void CreateReservationMaps()
    {
        CreateMap<Reservation, ReservationResponse>();
        CreateMap<CreateReservationRequest, Reservation>();
    }

    private void CreateModerationMaps()
    {
        CreateMap<Place, ModerationPlaceSearchResponse>()
            .ForMember(response => response.CityName,
                options =>
                    options.MapFrom(place => place.City.Name));

        CreateMap<Moderation, ModerationResponse>();
    }

    private void CreateLocationMaps()
    {
        CreateMap<AddPlaceLocationRequest, Location>();
    }
}