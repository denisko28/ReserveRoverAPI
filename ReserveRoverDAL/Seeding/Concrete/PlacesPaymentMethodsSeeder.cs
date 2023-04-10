using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class PlacesPaymentsSeeder : ISeeder<PlacePaymentMethod>
{
    private static readonly List<PlacePaymentMethod> PlacesPaymentMethods = new()
    {
        new PlacePaymentMethod
        {
            PlaceId = 1,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 1,
            Method = 1
        },
        new PlacePaymentMethod
        {
            PlaceId = 2,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 3,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 3,
            Method = 1
        },
        new PlacePaymentMethod
        {
            PlaceId = 4,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 4,
            Method = 1
        },
        new PlacePaymentMethod
        {
            PlaceId = 5,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 6,
            Method = 0
        },
        new PlacePaymentMethod
        {
            PlaceId = 6,
            Method = 1
        }
    };

    public void Seed(EntityTypeBuilder<PlacePaymentMethod> builder)
    {
        builder.HasData(PlacesPaymentMethods);
    }
}