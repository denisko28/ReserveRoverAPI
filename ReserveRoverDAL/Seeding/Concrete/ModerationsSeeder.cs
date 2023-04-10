using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReserveRoverDAL.Entities;
using ReserveRoverDAL.Seeding.Abstract;

namespace ReserveRoverDAL.Seeding.Concrete;

public class ModerationsSeeder : ISeeder<Moderation>
{
    private static readonly List<Moderation> Moderations = new()
    {
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 1,
            ModeratorId = "Mod1",
            Date = DateOnly.Parse("2023-03-08"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 2,
            ModeratorId = "Mod2",
            Date = DateOnly.Parse("2023-03-28"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 3,
            ModeratorId = "Mod3",
            Date = DateOnly.Parse("2023-04-02"),
            Status = 2
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 4,
            ModeratorId = "Mod4",
            Date = DateOnly.Parse("2023-04-17"),
            Status = 1
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 5,
            ModeratorId = "Mod5",
            Date = null,
            Status = 0
        },
        new Moderation
        {
            Id = Guid.NewGuid(),
            PlaceId = 6,
            ModeratorId = "Mod6",
            Date = DateOnly.Parse("2023-04-02"),
            Status = 2
        }
    };

    public void Seed(EntityTypeBuilder<Moderation> builder)
    {
        builder.HasData(Moderations);
    }
}