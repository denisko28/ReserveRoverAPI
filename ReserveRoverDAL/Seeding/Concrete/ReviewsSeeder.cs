using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ReviewsSeeder : ISeeder<Review>
{
    private static readonly List<Review> Reviews = new()
    {
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "U1",
            CreationDate = DateOnly.Parse("2023-04-09"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "U2",
            CreationDate = DateOnly.Parse("2023-04-11"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "U10",
            CreationDate = DateOnly.Parse("2023-04-12"),
            Mark = 5,
            Comment = "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "U11",
            CreationDate = DateOnly.Parse("2023-04-13"),
            Mark = 5,
            Comment = "Піца була смачна. Рекомендую)",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "U12",
            CreationDate = DateOnly.Parse("2023-04-14"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "U13",
            CreationDate = DateOnly.Parse("2023-04-17"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "U14",
            CreationDate = DateOnly.Parse("2023-04-18"),
            Mark = 4,
            Comment = "Вже другий раз не дають прибори.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "U15",
            CreationDate = DateOnly.Parse("2023-04-05"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "U16",
            CreationDate = DateOnly.Parse("2023-04-14"),
            Mark = 4,
            Comment = "Страви не підписані, мусили вгадувати.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U17",
            CreationDate = DateOnly.Parse("2023-04-04"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U18",
            CreationDate = DateOnly.Parse("2023-04-08"),
            Mark = 4,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U19",
            CreationDate = DateOnly.Parse("2023-04-09"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U20",
            CreationDate = DateOnly.Parse("2023-04-11"),
            Mark = 5,
            Comment = "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U21",
            CreationDate = DateOnly.Parse("2023-04-12"),
            Mark = 5,
            Comment = "Такої смачної їжі давно не куштувала",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U22",
            CreationDate = DateOnly.Parse("2023-04-16"),
            Mark = 3,
            Comment = "Шашлик з купою жил, сала, ледь жувався.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "U23",
            CreationDate = DateOnly.Parse("2023-04-16"),
            Mark = 5,
            Comment = "",
        }
    };

    public void Seed(EntityTypeBuilder<Review> builder)
    {
        builder.HasData(Reviews);
    }
}