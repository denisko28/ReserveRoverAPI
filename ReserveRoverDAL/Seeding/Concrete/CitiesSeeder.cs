using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class CitiesSeeder : ISeeder<City>
{
    private static readonly List<City> Cities = new()
    {
        new City { Id = 1, Name = "Чернівці" },
        new City { Id = 2, Name = "Київ" },
        new City { Id = 3, Name = "Львів" }
    };

    public void Seed(EntityTypeBuilder<City> builder)
    {
        builder.HasData(Cities);
    }
}