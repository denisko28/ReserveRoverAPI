using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class PlacesSeeder : ISeeder<Place>
{
    private static readonly List<Place> Places = new()
    {
        new Place
        {
            Id = 1,
            ManagerId = "M1",
            CityId = 1,
            Title = "Familia Grande",
            OpensAt = TimeOnly.Parse("10:00:00"),
            ClosesAt = TimeOnly.Parse("20:00:00"),
            AvgMark = 4.7m,
            AvgBill = 600,
            Address = "вул. Заньковецької, 20",
            PublicDate = DateOnly.Parse("2023-03-08"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 2,
            ManagerId = "M2",
            CityId = 1,
            Title = "Піца парк",
            OpensAt = TimeOnly.Parse("08:00:00"),
            ClosesAt = TimeOnly.Parse("20:00:00"),
            AvgMark = null,
            AvgBill = 300,
            Address = "вул. Небесної сотні 5а",
            PublicDate = DateOnly.Parse("2023-03-28"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 3,
            ManagerId = "M3",
            CityId = 2,
            Title = "Pang",
            OpensAt = TimeOnly.Parse("12:00:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = 4.8m,
            AvgBill = 950,
            Address = "вул. Івана Франка, 42Г",
            PublicDate = DateOnly.Parse("2023-04-02"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 4,
            ManagerId = "M4",
            CityId = 2,
            Title = "LAPASTA",
            OpensAt = TimeOnly.Parse("10:30:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = null,
            AvgBill = 800,
            Address = "вул. академіка Амосова, 96В",
            PublicDate = null,
            ModerationStatus = 1
        },
        new Place
        {
            Id = 5,
            ManagerId = "M5",
            CityId = 2,
            Title = "Пікантіко",
            OpensAt = TimeOnly.Parse("13:00:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = null,
            AvgBill = 400,
            Address = "вул. Івана Мазепи, 17Е",
            PublicDate = null,
            ModerationStatus = 0
        },
        new Place
        {
            Id = 6,
            ManagerId = "M6",
            CityId = 3,
            Title = "Ребра та вогонь",
            OpensAt = TimeOnly.Parse("11:30:00"),
            ClosesAt = TimeOnly.Parse("21:30:00"),
            AvgMark = 4.6m,
            AvgBill = 1250,
            Address = "вул. Січевих Стрільців, 119Б, заїзд з пр. Дорошенка",
            PublicDate = DateOnly.Parse("2023-04-02"),
            ModerationStatus = 2
        }
    };

    public void Seed(EntityTypeBuilder<Place> builder)
    {
        builder.HasData(Places);
    }
}