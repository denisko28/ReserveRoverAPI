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
            MainImageUrl = "https://assets.dots.live/misteram-public/1606a7ce-cf02-46c4-a097-7fe6759bde43.png",
            Title = "Familia Grande",
            OpensAt = TimeOnly.Parse("10:00:00"),
            ClosesAt = TimeOnly.Parse("20:00:00"),
            AvgMark = 4.7m,
            Popularity = 4,
            AvgBill = 600,
            Address = "вул. Заньковецької, 20",
            ImagesCount = 3,
            SubmissionDateTime = DateTime.Parse("2023/03/07 07:22:16"),
            PublicDate = DateOnly.Parse("2023-03-08"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 2,
            ManagerId = "M2",
            CityId = 1,
            MainImageUrl = "https://assets.dots.live/misteram-public/0627f92845e66bd4fdb662e3e6129ccc.png",
            Title = "Піца парк",
            OpensAt = TimeOnly.Parse("08:00:00"),
            ClosesAt = TimeOnly.Parse("20:00:00"),
            AvgMark = 4.25m,
            Popularity = 2,
            AvgBill = 300,
            Address = "вул. Небесної сотні 5а",
            ImagesCount = 2,
            SubmissionDateTime = DateTime.Parse("2023/03/26 18:44:09"),
            PublicDate = DateOnly.Parse("2023-03-28"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 3,
            ManagerId = "M3",
            CityId = 2,
            MainImageUrl = "https://assets.dots.live/misteram-public/2821669b-9921-4af9-acf8-a9b7e2e49a14.png",
            Title = "Pang",
            OpensAt = TimeOnly.Parse("12:00:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = 4.8m,
            Popularity = 12,
            AvgBill = 950,
            Address = "вул. Івана Франка, 42Г",
            ImagesCount = 2,
            SubmissionDateTime = DateTime.Parse("2023/04/01 14:31:57"),
            PublicDate = DateOnly.Parse("2023-04-02"),
            ModerationStatus = 2
        },
        new Place
        {
            Id = 4,
            ManagerId = "M4",
            CityId = 2,
            MainImageUrl = "https://assets.dots.live/misteram-public/f1d85bcd-7b2f-4180-8a89-b55ad10fe019.png",
            Title = "LAPASTA",
            OpensAt = TimeOnly.Parse("10:30:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = null,
            Popularity = 0,
            AvgBill = 800,
            Address = "вул. академіка Амосова, 96В",
            ImagesCount = 1,
            SubmissionDateTime = DateTime.Parse("2023/04/01 11:12:19"),
            PublicDate = null,
            ModerationStatus = 1
        },
        new Place
        {
            Id = 5,
            ManagerId = "M5",
            CityId = 2,
            MainImageUrl = "https://assets.dots.live/misteram-public/7b5d6db7213f6e9d012f625024b94cb7.png",
            Title = "Пікантіко",
            OpensAt = TimeOnly.Parse("13:00:00"),
            ClosesAt = TimeOnly.Parse("22:00:00"),
            AvgMark = null,
            Popularity = 0,
            AvgBill = 400,
            Address = "вул. Івана Мазепи, 17Е",
            ImagesCount = 2,
            SubmissionDateTime = DateTime.Parse("2023/04/02 23:43:37"),
            PublicDate = null,
            ModerationStatus = 0
        },
        new Place
        {
            Id = 6,
            ManagerId = "M6",
            CityId = 3,
            MainImageUrl = "https://assets.dots.live/misteram-public/fd01592e-08b9-4058-bd77-dcfd74201b72.png",
            Title = "Ребра та вогонь",
            OpensAt = TimeOnly.Parse("11:30:00"),
            ClosesAt = TimeOnly.Parse("21:30:00"),
            AvgMark = 4.6m,
            Popularity = 3,
            AvgBill = 1250,
            Address = "вул. Січевих Стрільців, 119Б, заїзд з пр. Дорошенка",
            ImagesCount = 2,
            SubmissionDateTime = DateTime.Parse("2023/04/02 16:50:28"),
            PublicDate = DateOnly.Parse("2023-04-03"),
            ModerationStatus = 2
        }
    };

    public void Seed(EntityTypeBuilder<Place> builder)
    {
        builder.HasData(Places);
    }
}