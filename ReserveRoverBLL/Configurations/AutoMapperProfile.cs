using AutoMapper;
using ReserveRoverBLL.DTO.Requests;
using ReserveRoverBLL.DTO.Responses;
using ReserveRoverBLL.Helpers.Models;
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
        CreateCitiesMaps();
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
        CreateMap<Reservation, UserReservationResponse>()
            .ForMember(response => response.PlaceImageUrl,
                options =>
                    options.MapFrom(reservation => reservation.TableSet.Place.MainImageUrl))
            .ForMember(response => response.PlaceTitle,
                options =>
                    options.MapFrom(reservation => reservation.TableSet.Place.Title));
        CreateMap<Reservation, PlaceReservationResponse>();
        CreateMap<TablesHelper.Table, TimelineReservationResponse>()
            .ForMember(response => response.TableCapacity,
                options =>
                    options.MapFrom(table => table.Capacity))
            .ForMember(response => response.TableReservations,
                options =>
                    options.MapFrom(table => table.Reservations.Select(reservation =>
                        new TimelineReservationResponse.TableReservation
                        {
                            Id = reservation.Id.ToString(),
                            BeginTime = reservation.ReservDate.ToDateTime(reservation.BeginTime),
                            EndTime = reservation.ReservDate.ToDateTime(reservation.EndTime)
                        })));
        
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

    private void CreateCitiesMaps()
    {
        CreateMap<City, CityResponse>();
    }
}