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
            AuthorId = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            CreationDate = DateOnly.Parse("2023-04-09"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "vHqgNXnqfcQqILCTRrC1qm2kfMh1",
            CreationDate = DateOnly.Parse("2023-04-11"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            AuthorId = "vHqgNXnqfcQqILCTRrC1qm2kfMh1",
            CreationDate = DateOnly.Parse("2023-04-11"),
            Mark = 4,
            Comment = "Піца смачна, атмосфера в закладі приємна, але варто було б трохи оновити інтер'єр.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            CreationDate = DateOnly.Parse("2023-04-12"),
            Mark = 5,
            Comment = "Сама смачна піцца в Че. Я ваш клієнт на віки-вічні",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "En6jfcgABnQqw5wNBIpHLvMlB102",
            CreationDate = DateOnly.Parse("2023-04-13"),
            Mark = 5,
            Comment = "Піца була смачна. Рекомендую)",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "En6jfcgABnQqw5wNBIpHLvMlB102",
            CreationDate = DateOnly.Parse("2023-04-14"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1",
            CreationDate = DateOnly.Parse("2023-04-17"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            AuthorId = "vHqgNXnqfcQqILCTRrC1qm2kfMh1",
            CreationDate = DateOnly.Parse("2023-04-18"),
            Mark = 4,
            Comment = "Вже другий раз не дають прибори.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "D7Cy0pTcq0NszfWnTiiqLyfh0eI3",
            CreationDate = DateOnly.Parse("2023-04-05"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            AuthorId = "8M8DY0scwgR9gfbCvvzfXM6FnQ53",
            CreationDate = DateOnly.Parse("2023-04-14"),
            Mark = 4,
            Comment = "Страви не підписані, мусили вгадувати.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            AuthorId = "D7Cy0pTcq0NszfWnTiiqLyfh0eI3",
            CreationDate = DateOnly.Parse("2023-04-15"),
            Mark = 5,
            Comment = "Піца по бувовинськи - це смак мого дитинства. Смачно, швидко, бюджетно.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            AuthorId = "jidZO6WQMiYOSRIEE5ONUREmRpd2",
            CreationDate = DateOnly.Parse("2023-05-03"),
            Mark = 3,
            Comment = "На жаль, не сподобалось, окрошка була пересолена, овочі в салаті в'ялі...",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            AuthorId = "8M8DY0scwgR9gfbCvvzfXM6FnQ53",
            CreationDate = DateOnly.Parse("2023-05-07"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "8M8DY0scwgR9gfbCvvzfXM6FnQ53",
            CreationDate = DateOnly.Parse("2023-04-04"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "Q37k5ec7ccWjWuk7mPwMOQr3hoy2",
            CreationDate = DateOnly.Parse("2023-04-08"),
            Mark = 4,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "L31xc7GbqoVTjPFlyyWjDFqhc6u1",
            CreationDate = DateOnly.Parse("2023-04-09"),
            Mark = 5,
            Comment = "",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "D7Cy0pTcq0NszfWnTiiqLyfh0eI3",
            CreationDate = DateOnly.Parse("2023-04-11"),
            Mark = 5,
            Comment = "Копчене курча бездоганне, а от свиня за життя займалася фітнесом, міцна та підтягнута занадто)",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "CCK7UNofA4XUpaSRC5W3RdNoMxm2",
            CreationDate = DateOnly.Parse("2023-04-12"),
            Mark = 5,
            Comment = "Такої смачної їжі давно не куштувала",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "TWkGRrgJeiRbBxFHepdxr5Ye0Rl1",
            CreationDate = DateOnly.Parse("2023-04-16"),
            Mark = 3,
            Comment = "Шашлик з купою жил, сала, ледь жувався.",
        },
        new Review
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            AuthorId = "jidZO6WQMiYOSRIEE5ONUREmRpd2",
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