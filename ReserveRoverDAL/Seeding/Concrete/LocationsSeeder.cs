using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class LocationsSeeder : ISeeder<Location>
{
    private static readonly List<Location> Locations = new()
    {
        new Location
        {
            PlaceId = 1,
            Latitude = 48.291845m,
            Longitude = 25.930247m
        },
        new Location
        {
            PlaceId = 2,
            Latitude = 48.290586m,
            Longitude = 25.935982m
        },
        new Location
        {
            PlaceId = 3,
            Latitude = 50.439802m,
            Longitude = 30.538339m
        },
        new Location
        {
            PlaceId = 4,
            Latitude = 50.421874m,
            Longitude = 30.466707m
        },
        new Location
        {
            PlaceId = 5,
            Latitude = 50.480726m,
            Longitude = 30.604961m
        },
        new Location
        {
            PlaceId = 6,
            Latitude = 49.840546m,
            Longitude = 24.024734m
        },
    };

    public void Seed(EntityTypeBuilder<Location> builder)
    {
        builder.HasData(Locations);
    }
}